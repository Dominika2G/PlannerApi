using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.DAL;
using PlannerApi.Models;
using PlannerApi.Models.Authentication;
using PlannerApi.Models.SprintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Controllers.Planner
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintsController : ControllerBase
    {
        #region Properties
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private DatabaseContext _context;
        #endregion

        #region Constructor
        public SprintsController(UserManager<User> usermanager, RoleManager<IdentityRole> roleManager, DatabaseContext context)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _context = context;
        }
        #endregion

        #region GetProjectsWithSprints
        [HttpGet("{id}")]
        [Authorize]
        [Route("GetProjectWithSprints")]
        public ActionResult GetProjectWithSprints([FromHeader] int id)
        {
            //var id = 1;
            var project = _context.Projects.FirstOrDefault(p => p.Id == id);
            var users = _context.ProjectsUsers.Where(p => p.ProjectId == id).Select(u => u.UserId).ToArray();

            if (project != null)
            {
                return Ok(new
                {
                    project.Id,
                    project.Name,
                    Users = _context.ProjectsUsers.Where(p => p.ProjectId == id).Select(u => new { 
                        u.UserId,
                        u.User.UserName
                    }).ToArray(),
                    Sprints = _context.Sprints.Where(p => p.ProjectId == id).Select(s => new { 
                        s.SprintId,
                        s.Name,
                        StartTime  = s.StartDate,
                        EndTime = s.EndDate
                    }).ToArray()
                });
            }

            if (project == null)
            {
                return NotFound();
            }

            return Conflict();

        }
        #endregion

    }

}
