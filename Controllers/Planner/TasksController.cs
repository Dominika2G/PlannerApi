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
        [Authorize]
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
                        LastPageIndex = 0,
                        MaxPageSize = int.MaxValue,
                        PageIndex = 0,
                        Pages = tasks.Select(t => new 
                        {
                            Id = t.TaskId,
                            Description = t.Description,
                            Name = t.Name,
                            SprintId = t.SprintId,
                            EstimatedTime = t.EstimatedTime == null ? 0 : t.EstimatedTime,
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

        [HttpGet]
        [Authorize]
        [Route("GetComments/{id}")]
        public ActionResult GetComments(int id)
        {
            var result = _context.Comments.Where(t => t.TaskId == id).Select(c => new
            {
                Author = _context.Users.First(u => u.Id == c.AuthorId).UserName,
                Content = c.Content,
                CreationTime = c.StartDate
            }).ToArray();

            return Ok(result);
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
                Id = t.TaskId,
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

        [HttpGet]
        [Authorize]
        [Route("GetTaskDetails/{id}")]
        public ActionResult GetTaskDetails(int id)
        {
            var result = _context.Tasks.Where(x => x.TaskId == id).Select(t => new
            {
                Id = t.TaskId,
                t.Name,
                t.Description,
                AssigneeName = t.Assignee.UserName,
                ReporterName = t.Reporter.UserName,
                t.SprintId,
                SprintName = t.Sprint.Name,
                TypeName = t.TaskType.Name,
                StatusName = t.TaskStatus.TaskName,
                PriorityName = t.TaskPriority.Name,
                t.EstimatedTime
            }).SingleOrDefault();

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

        [HttpGet]
        [Authorize]
        [Route("GetManagedTaskDetails/{id}")]
        public ActionResult GetManagedTaskDetails(int id)
        {
            var result = _context.Tasks.Where(x => x.TaskId == id).Select(t => new
            {
                Id = t.TaskId,
                t.Name,
                t.Description,
                AssigneeId = t.Reporter.Id,
                t.SprintId,
                t.TaskTypeId,
                StatusId = t.TaskStatusId,
                PriorityId = t.TaskPriorityId,
                t.EstimatedTime
            }).SingleOrDefault();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion GetManagedTaskDetails

        #region GetNewTaskManagementOptions
        [HttpGet]
        [Authorize]
        [Route("GetNewTaskManagementOptions/{projectId}")]
        public ActionResult GetNewTaskManagementOptions(int projectId)
        {
            DateTime thisDay = DateTime.Today;

            return Ok(new
            {
                PermittedStatuses = _context.TaskStatuses.Select(s => new { Id = s.TaskStatusId, StatusName = s.TaskName }).ToArray(),
                PermittedTaskTypes = _context.TaskTypes.Select(t => new { Id = t.TaskTypeId, TypeName = t.Name }).ToArray(),
                PermittedTaskPriorities = _context.TaskPriorities.Select(p => new { Id = p.TaskPriorityId, PriorityName = p.Name }).ToArray(),
                PermittedAssignableSprints = _context.Sprints.Where(x => x.EndDate.CompareTo(thisDay) > 0 && x.ProjectId == projectId).Select(s => new { Id = s.SprintId, s.Name }).ToArray(),
                PermittedAssignees = _context.ProjectsUsers.Where(x => x.ProjectId == projectId)
                                                           .Select(u => new { Id = u.UserId, Name = u.User.UserName })
                                                           .ToArray()
            });
        }
        #endregion GetNewTaskManagementOptions

        #region GetNewTaskManagementOptions
        [HttpGet]
        [Authorize]
        [Route("GetTaskManagementOptions/{taskId}")]
        public ActionResult GetTaskManagementOptions(int taskId)
        {
            DateTime thisDay = DateTime.Today;
            var sprintIdOfTask = _context.Tasks.First(x => x.TaskId == taskId).SprintId;
            var projectIdOfTask = _context.Sprints.First(x => x.SprintId == sprintIdOfTask).ProjectId;

            var data = new
            {
                PermittedStatuses = _context.TaskStatuses.Select(s => new { Id = s.TaskStatusId, StatusName = s.TaskName }).ToArray(),
                PermittedTaskTypes = _context.TaskTypes.Select(t => new { Id = t.TaskTypeId, TypeName = t.Name }).ToArray(),
                PermittedTaskPriorities = _context.TaskPriorities.Select(p => new { Id = p.TaskPriorityId, PriorityName = p.Name }).ToArray(),
                PermittedAssignableSprints = _context.Sprints.Where(x => x.EndDate.CompareTo(thisDay) > 0 && x.ProjectId == projectIdOfTask).Select(s => new { Id = s.SprintId, s.Name }).ToArray(),
                PermittedAssignees = _context.ProjectsUsers.Where(x => x.ProjectId == projectIdOfTask)
                                                           .Select(u => new { Id = u.UserId, Name = u.User.UserName })
                                                           .ToArray()
            };
            return Ok(data);
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
                AssigneeId = model.AssigneeId,
                SprintId = model.SprintId,
                TaskStatusId = (int)model.StatusId,
                TaskTypeId = (int)model.TaskTypeId,
                TaskPriorityId = (int)model.PriorityId,
                EstimatedTime = model.EstimatedTime,
                ReporterId = User.Claims.First(c => c.Type == "UserID").Value
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

            if (!string.IsNullOrEmpty(model.AssigneeId))
            {
                existingTask.AssigneeId = model.AssigneeId;
            }

            if (model.EstimatedTime != null)
            {
                existingTask.EstimatedTime = model.EstimatedTime;
            }

            if(model.PriorityId != null)
            {
                existingTask.TaskPriorityId = (int)model.PriorityId;
            }

            if(model.StatusId != null)
            {
                existingTask.TaskStatusId = (int)model.StatusId;
            }

            if(model.TaskTypeId != null)
            {
                existingTask.TaskTypeId = (int)model.TaskTypeId;
            }

            if(model.SprintId != null)
            {
                existingTask.SprintId = (int)model.SprintId;
            }

            //_context.Tasks.Update(existingTask);
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
            var date = DateTime.Now;
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