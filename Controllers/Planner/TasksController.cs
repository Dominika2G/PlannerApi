using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.DAL;
using PlannerApi.Models.Authentication;

namespace PlannerApi.Controllers.Planner
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        #region Properties

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private DatabaseContext _context;

        #endregion Properties

        #region Constructor

        public TasksController(UserManager<User> usermanager, RoleManager<IdentityRole> roleManager, DatabaseContext context)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _context = context;
        }

        #endregion Constructor

        #region GetComments

        [HttpGet("{id}")]
        [Authorize]
        [Route("GetComments")]
        public ActionResult GetComments([FromHeader] int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            var comments = _context.Tasks.Where(t => t.TaskId == id).Select(l => l.CommentsList).ToArray();
            if (comments.Count() > 0)
            {
                var result = task.CommentsList.Select(c => new
                {
                    Author = _context.Users.Where(u => u.Id == c.AuthorId).Select(p => p.UserName).FirstOrDefault(),
                    Content = c.Content,
                    CreationTime = c.StartDate
                }).ToArray();
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            /*var result = task.CommentsList.Select(c => new
            {
                Author = _context.Users.Where(u => u.Id == c.AuthorId).Select(p => p.UserName).FirstOrDefault(),
                Content = c.Content,
                CreationTime = c.StartDate
            }).ToArray();*/

            /*if(result != null)
            {
                return Ok(result);
            }*/

            return NotFound();

            /*return Ok(task.CommentsList.Select(c => new
            {
                Author = _context.Users.Where(u => u.Id == c.AuthorId).Select(p => p.UserName ).FirstOrDefault(),
                Content = c.Content,
                CreationTime = c.StartDate
            }).ToArray());*/
        }

        #endregion GetComments

        [HttpDelete]
        [Authorize]
        [Route("DeleteTask")]
        /*public async Task<IActionResult> DeleteProject([FromBody] int id)*/
        public async Task<IActionResult> DeleteTask()
        {
            var id = 1;
            var project = _context.Tasks.FirstOrDefault(x => x.TaskId == id);
            //var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                NotFound();
            }

            if (project != null)
            {
                _context.Tasks.Remove(project);
                _context.SaveChanges();
                return Ok();
            }

            return Conflict();
        }

        #region GetOwnTask

        [HttpGet]
        [Authorize]
        [Route("GetOwnTasks")]
        public async Task<IActionResult> GetOwnTasks()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var result = _context.Tasks.Where(x => x.AssigneeId == userId).Select(t => new
            {
                t.TaskId,
                t.Name,
                t.Description,
                AssignedName = t.Assignee.UserName,
                t.SprintId,
                SprintName = t.Sprint.Name,
                TypeName = t.TaskType.Name,
                StatusName = t.TaskStatus.TaskName,
                PriorityName = t.TaskPriority.Name,
                t.EstimatedTime
            }).ToArray();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

            /*return Ok( _context.Tasks.Where(x => x.AssigneeId == userId).Select(t => new {
                t.TaskId,
                t.Name,
                t.Description,
                AssignedName = t.Reporter.UserName,
                t.SprintId,
                SprintName = t.Sprint.Name,
                TypeName = t.TaskType.Name,
                StatusName = t.TaskStatus.TaskName,
                PriorityName = t.TaskPriority.Name,
                t.EstimatedTime
            }).ToArray());*/
        }

        #endregion GetOwnTask

        #region GetTaskDetails

        [HttpGet("{id}")]
        [Authorize]
        [Route("GetTaskDetails")]
        public ActionResult GetTaskDetails([FromHeader] int id)
        {
            //var id = 1;
            var result = _context.Tasks.Where(x => x.TaskId == id).Select(t => new
            {
                t.TaskId,
                t.Name,
                t.Description,
                AssignedName = t.Reporter.UserName,
                t.SprintId,
                SprintName = t.Sprint.Name,
                TypeName = t.TaskType.Name,
                StatusName = t.TaskStatus.TaskName,
                PriorityName = t.TaskPriority.Name,
                t.EstimatedTime
            }).ToArray();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
            /*return Ok(_context.Tasks.Where(x => x.TaskId == id).Select(t => new {
                t.TaskId,
                t.Name,
                t.Description,
                AssignedName = t.Reporter.UserName,
                t.SprintId,
                SprintName = t.Sprint.Name,
                TypeName = t.TaskType.Name,
                StatusName = t.TaskStatus.TaskName,
                PriorityName = t.TaskPriority.Name,
                t.EstimatedTime
            }).ToArray());*/
        }

        #endregion GetTaskDetails

        #region GetManagedTaskDetails

        [HttpGet("{id}")]
        [Authorize]
        [Route("GetManagedTaskDetails")]
        public ActionResult GetManagedTaskDetails([FromHeader] int id)
        {
            //var id = 3;
            var result = _context.Tasks.Where(x => x.TaskId == id).Select(t => new
            {
                t.TaskId,
                t.Name,
                t.Description,
                AssignedId = t.Reporter.Id,
                t.SprintId,
                t.TaskTypeId,
                t.TaskStatusId,
                t.TaskPriorityId,
                t.EstimatedTime
            }).ToArray();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
            /*return Ok(_context.Tasks.Where(x => x.TaskId == id).Select(t => new {
                t.TaskId,
                t.Name,
                t.Description,
                AssignedId = t.Reporter.Id,
                t.SprintId,
                t.TaskTypeId,
                t.TaskStatusId,
                t.TaskPriorityId,
                t.EstimatedTime
            }).ToArray());*/
        }

        #endregion GetManagedTaskDetails

        #region GetNewTaskManagementOptions

        [HttpGet("{projectId}")]
        [Authorize]
        [Route("GetNewTaskManagementOptions")]
        public ActionResult GetNewTaskManagementOptions([FromHeader] int projectId)
        {
            DateTime thisDay = DateTime.Today;

            return Ok(new
            {
                PermittedStatuses = _context.TaskStatuses.Select(s => new { s.TaskStatusId, s.TaskName }).ToArray(),
                PermittedTaskTypes = _context.TaskTypes.Select(t => new { t.TaskTypeId, t.Name }).ToArray(),
                PermittedTaskPriorities = _context.TaskPriorities.Select(p => new { p.TaskPriorityId, p.Name }).ToArray(),
                PermittedAssignableSprints = _context.Sprints.Where(x => x.EndDate.CompareTo(thisDay) > 0).Select(s => new { s.SprintId, s.Name }).ToArray(),
                PermittedAssignees = _context.Projects.Where(p => p.Id == projectId).Select(p => p.ProjectsUsers.Select(u => new { u.UserId, u.User.UserName }).ToArray()).ToArray()
            });
        }

        #endregion GetNewTaskManagementOptions

        #region

        [HttpGet("{taskId}")]
        [Authorize]
        [Route("GetTaskManagementOptions")]
        public ActionResult GetTaskManagementOptions([FromHeader] int taskId)
        {
            DateTime thisDay = DateTime.Today;

            return Ok(new
            {
                PermittedStatuses = _context.TaskStatuses.Select(s => new { s.TaskStatusId, s.TaskName }).ToArray(),
                PermittedTaskTypes = _context.TaskTypes.Select(t => new { t.TaskTypeId, t.Name }).ToArray(),
                PermittedTaskPriorities = _context.TaskPriorities.Select(p => new { p.TaskPriorityId, p.Name }).ToArray(),
                PermittedAssignableSprints = _context.Sprints.Where(x => x.EndDate.CompareTo(thisDay) > 0).Select(s => new { s.SprintId, s.Name }).ToArray(),
                PermittedAssignees = _context.Projects.Where(p => p.Id == 1).Select(p => p.ProjectsUsers).ToArray()
            });
        }

        #endregion
    }
}