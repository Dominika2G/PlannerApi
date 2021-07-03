using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerApi.DAL;
using PlannerApi.Models.Authentication;
using PlannerApi.Models.Kanban;
using PlannerApi.Models.TaskModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Controllers.Planner
{
    [Route("api/[controller]")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        #region Properties

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private DatabaseContext _context;

        #endregion 

        #region Constructor
        public KanbanController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, DatabaseContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        #endregion

        #region GetTasks
        [HttpGet]
        [Authorize]
        [Route("GetTasks")]
        public ActionResult GetTasks()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var sprintWithTheMostAssignedTasks = _context.Tasks.Where(i => i.AssigneeId == userId)
                                                               .ToArray()
                                                               .GroupBy(i => i.SprintId)
                                                               .OrderByDescending(i => i.Count())
                                                               .FirstOrDefault()?.Key;

            if (!sprintWithTheMostAssignedTasks.HasValue)
            {
                sprintWithTheMostAssignedTasks = _context.ProjectsUsers.Where(i => i.UserId == userId)
                                                                       .SelectMany(i => i.Project.Sprints)
                                                                       .SelectMany(i => i.Tasks)
                                                                       .ToArray()
                                                                       .GroupBy(i => i.SprintId)
                                                                       .OrderByDescending(i => i.Count())
                                                                       .First().Key;
            }

            return this.GetTasks(sprintWithTheMostAssignedTasks.Value);
        }
        #endregion

        #region GetTasks/id
        [HttpGet]
        [Authorize]
        [Route("GetTasks/{id}")]
        public ActionResult GetTasks(int id)
        {
            var taskRows = _context.Tasks.Where(i => i.SprintId == id)
                .OrderBy(i => i.Assignee.UserName)
                .GroupBy(i => i.AssigneeId)
                .Select(ga => new KanbanRow
                {
                    Assignee = new SimpleEnlistedUser()
                    {
                        Id = ga.Key,
                        Name = _context.Users.First(u => u.Id == ga.Key).UserName,
                    }
                }).ToArray();

            var availableTaskStatuses = _context.TaskStatuses.OrderBy(i => i.TaskStatusId);

            foreach (var taskRow in taskRows)
            {
                taskRow.TaskCells = availableTaskStatuses.Select(stat => new KanbanCell
                {
                    Status = new SimpleTaskStatus()
                    {
                        Id = stat.TaskStatusId,
                        StatusName = stat.TaskName
                    }
                }).ToArray();

                foreach (var taskCell in taskRow.TaskCells)
                {
                    taskCell.Tasks = _context.Tasks.Where(i => i.SprintId == id &&
                        i.AssigneeId == taskRow.Assignee.Id &&
                        i.TaskStatusId == taskCell.Status.Id)
                        .OrderBy(i => i.TaskId)
                    .Select(st => new SimpleTask()
                    {
                        Id = st.TaskId,
                        Name = st.Name,
                        Description = st.Description,
                        ReporterName = st.Reporter.UserName,
                        AssigneeName = st.Assignee.UserName,
                        SprintName = st.Sprint.Name,
                        SprintId = st.SprintId.Value,
                        TypeName = st.TaskType.Name,
                        StatusName = st.TaskStatus.TaskName,
                        PriorityName = st.TaskPriority.Name,
                        EstimatedTime = st.EstimatedTime.Value
                    }).ToArray();
                }
            }
            
            return Ok(new KanbanTaskCollection()
            {
                SprintId = id,
                AllowedStatusNames = availableTaskStatuses.Select(i => i.TaskName)
                                                          .ToArray(),
                TaskRows = taskRows
            });
        }
        #endregion

        #region GetCurrentSprints
        [HttpGet]
        [Authorize]
        [Route("GetCurrentSprints")]
        public async Task<ActionResult<List<Object>>> GetCurrentSprints()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var sprints = _context.Sprints.Where(i => i.EndDate > DateTime.Today &&
                i.Project.ProjectsUsers.Any(x => x.UserId == userId));

            return Ok(sprints.Select(i => new
            {
                SprintId = i.SprintId,
                SprintName = i.Name,
                ProjectName = i.Project.Name
            }));
            
        }
        #endregion

        #region SetChanges
        [HttpPost]
        [Authorize]
        [Route("SetChanges")]
        public async Task<ActionResult> SetChanges(KanbanChangesCollection collection)
        {
            foreach(var taskChange in collection.Changes)
            {
                var updatedTask = _context.Tasks.First(i => i.TaskId == taskChange.TaskId);
                updatedTask.AssigneeId = taskChange.AssignedUserId;
                updatedTask.TaskStatusId = taskChange.SetStatusId;
            }
            await _context.SaveChangesAsync();

            return Ok(new { ErrorInfo = "" });
        }
        #endregion
    }
}
