using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.DAL;
using PlannerApi.Models.Authentication;
using PlannerApi.Models.TaskModel;
using PlannerApi.Models.Projects;
using System.Threading.Tasks;
using PlannerApi.Models.Pagination;

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

        #region GetSprintWithTasks
        [HttpGet]
       // [Authorize]
        [Route("GetSprintWithTasks/{id}")]
        public ActionResult GetSprintWithTasks(int id)
        {
            var sprint = _context.Sprints.FirstOrDefault(p => p.SprintId == id);
            var project = _context.Projects.FirstOrDefault(p => p.Id == sprint.ProjectId);
            var tasks = _context.Tasks.Where(t => t.SprintId == sprint.SprintId).ToList();
            if (sprint != null)
            {
                return Ok(new
                {
                    ProjectId = sprint.ProjectId,
                    ProjectName = project.Name,
                    SprintName = sprint.Name,
                    PageOfTasks = new
                    {
                        HasNextPage = false,
                        HasPreviousPage = false,
                        LastPageIndex = 1,
                        MaxPageSize = int.MaxValue,
                        PageIndex = 1,
                        Pages = tasks.Select(t => new 
                        {
                            Id = t.TaskId,
                            Description = t.Description,
                            Name = t.Name,
                            SprintId = t.SprintId,
                            EstimatedTime = 10,
                            SprintName = sprint.Name,
                            PriorityName = _context.TaskPriorities.FirstOrDefault(x => x.TaskPriorityId == t.TaskPriorityId).Name,
                            ReporterName = _context.Users.FirstOrDefault(u => u.Id == t.ReporterId).UserName,
                            AssigneeName = _context.Users.FirstOrDefault(u => u.Id == t.AssigneeId).UserName,
                            StatusName = _context.TaskStatuses.FirstOrDefault(s => s.TaskStatusId == t.TaskStatusId).TaskName,
                            TypeName = _context.TaskTypes.FirstOrDefault(x => x.TaskTypeId == t.TaskTypeId).Name
                        }).ToList()
                    }

                });
            }
            else if (sprint == null)
            {
                return NotFound();
            }
            return Conflict();
            //var data = from sp in _context.Sprints
            //           join tsk in _context.Tasks on sp.SprintId equals tsk.SprintId
            //           where sp.SprintId == id
            //           select new { sp, tsk };

            /*var sprint = _context.Sprints.FirstOrDefault(t => t.SprintId == id);
            var tasks = sprint.Tasks;

            if (sprint != null)
            {
                SimpleSprintWithTasks pageOfTasks = new SimpleSprintWithTasks()
                {
                    ProjectId = id,
                    ProjectName = sprint.Project.Name,
                    SprintName = sprint.Name,
                    PageOfTasks = new Models.Pagination.DataPage<SimpleTask>()
                    {
                        HasNextPage = false,
                        HasPreviousPage = false,
                        LastPageIndex = 1,
                        MaxPageSize = int.MaxValue,
                        PageIndex = 1,
                        Pages = tasks.Select(t => new SimpleTask
                        {
                            Id = t.TaskId,
                            Description = t.Description,
                            Name = t.Name,
                            SprintId = t.SprintId.Value,
                            SprintName = t.Sprint.Name,
                            AssigneeName = t.Assignee.UserName,
                            EstimatedTime = 10,
                            StatusName = t.TaskStatus.TaskName,
                            PriorityName = t.TaskPriority.Name,
                            ReporterName = t.Reporter.UserName,
                            TypeName = t.TaskType.Name
                        }).ToList()
                    }
                };
                return Ok(pageOfTasks);
            }
            return NotFound();*/
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

        #region DeleteTask

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

        #region CreateTask
        [HttpPost]
        [Authorize]
        [Route("CreateTask")]
        public async Task<ActionResult> CreateTask(CreateTaskModel model)
        {
            var task = new Models.Projects.Task
            {
                Name = model.Name,
                Description = model.Description,
                AssigneeId = model.AssigneedId,
                SprintId = model.SprintId,
                TaskStatusId = (int)model.TaskStatusId,
                TaskTypeId = (int)model.TaskTypeId,
                TaskPriorityId = (int)model.TaskPriorityId,
                EstimatedTime = model.EstimatedTime
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion

        #region UpdateTask
        [HttpPatch]
        [Authorize]
        [Route("UpdateTask")]
        public async Task<ActionResult> UpdateTask(CreateTaskModel model)
        {
            var existingTask = _context.Tasks.FirstOrDefault(t => t.TaskId == model.Id);

            if(existingTask == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                existingTask.Name = model.Name;
            }

            if (!string.IsNullOrEmpty(model.Description))
            {
                existingTask.Description = model.Description;
            }

            if (!string.IsNullOrEmpty(model.AssigneedId))
            {
                existingTask.AssigneeId = model.AssigneedId;
            }

            if (model.EstimatedTime != null)
            {
                existingTask.EstimatedTime = model.EstimatedTime;
            }

            if(model.TaskPriorityId != null)
            {
                existingTask.TaskPriorityId = (int)model.TaskPriorityId;
            }

            if(model.TaskStatusId != null)
            {
                existingTask.TaskStatusId = (int)model.TaskStatusId;
            }

            if(model.TaskTypeId != null)
            {
                existingTask.TaskTypeId = (int)model.TaskTypeId;
            }

            if(model.SprintId != null)
            {
                existingTask.SprintId = (int)model.SprintId;
            }

            _context.Tasks.Update(existingTask);
            _context.SaveChanges();

            return Ok();
        }
        #endregion

        #region AppendCommentForTask
        [HttpPost]
        [Authorize]
        [Route("AppendCommentForTask")]
        public async Task<ActionResult> AddComment(CommentModel model)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var date = DateTime.Today;
            var comments = new Comments
            {
                AuthorId = userId,
                Content = model.CommentContent,
                TaskId = model.TaskId,
                StartDate = date
            };

            await _context.Comments.AddAsync(comments);
            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion
    }
}