using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        /*#region GetTasks
        [HttpGet]
        [Authorize]
        [Route("GetTasks")]
                public ActionResult GetTasks()
                {
                    var kanban = new
                    {
                        SprintId = 5,
                        AllowedStatusNames = _context.TaskStatuses.Select(s => new { Id = s.TaskStatusId, StatusName = s.TaskName }).ToArray(),
                        TaskRows = new 

                    };
                }
        #endregion*/

/*        #region GetTasks/id
        [HttpGet]
        [Authorize]
        [Route("GetTasks/{id}")]
        #endregion
*/
        #region GetCurrentSprints
        [HttpGet]
        [Authorize]
        [Route("GetCurrentSprints")]

        public async Task<ActionResult<List<Object>>> getCurrentSprints()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var sprints = _context.ProjectsUsers
                .Where(x => x.UserId == userId)
                .Select(x => x.Project.Name);

            return Ok(_context.ProjectsUsers.Where(x => x.UserId == userId).Select(x => new {
                x.Project.Name,
                springName = x.Project.Sprints.Select(x => x.Name),
                sprintId = x.Project.Sprints.Select(x => x.SprintId)
            }));
        }
        #endregion
/*
        #region SetChanges
        [HttpPost]
        [Authorize]
        [Route("SetChanges")]
        #endregion*/
    }
}
