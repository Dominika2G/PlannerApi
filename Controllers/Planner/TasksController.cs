using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.DAL;
using PlannerApi.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        #endregion

        #region Constructor
        public TasksController(UserManager<User> usermanager, RoleManager<IdentityRole> roleManager, DatabaseContext context)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _context = context;
        }
        #endregion

        #region GetComments 
        [HttpGet("{id}")]
        [Authorize]
        [Route("GetComments")]
        public ActionResult GetComments([FromHeader] int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            var comments = _context.Tasks.Where(t => t.TaskId == id).Select(l => l.CommentsList).ToArray();
            if(comments.Count() > 0)
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
        #endregion

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

            if(result != null)
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

        #endregion

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

            if(result != null)
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
        #endregion

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

            if(result != null)
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
        #endregion
    }
}
