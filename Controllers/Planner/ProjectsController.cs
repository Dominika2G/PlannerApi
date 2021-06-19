using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.DAL;
using PlannerApi.Models;
using PlannerApi.Models.Authentication;

namespace PlannerApi.Controllers.Planner
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        #region Properties

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private DatabaseContext _context;

        #endregion Properties

        #region Constructor

        public ProjectsController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, DatabaseContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        #endregion Constructor

        #region GetProjects

        [HttpGet]
        [Authorize]
        [Route("GetProjects")]
        public async Task<ActionResult<List<Object>>> GetProjects()
        {
            return Ok(_context.Projects.Select(p => new
            {
                p.Id,
                p.Name
            }).ToArray());
        }

        #endregion GetProjects

        //DOKOŃCZYĆ USÓWANIE!!!!!

        #region DeleteProject

        /*[HttpDelete("{id}")]*/

        [HttpDelete]
        [Authorize]
        [Route("DeleteProject")]
        /*public async Task<IActionResult> DeleteProject([FromBody] int id)*/
        public async Task<IActionResult> DeleteProject()
        {
            var id = 1;
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);
            //var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                NotFound();
            }

            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
                return Ok();
            }

            return Conflict();
        }

        #endregion DeleteProject

        #region GetProjectDetails

        //[HttpGet("id")]
        [HttpGet]
        [Authorize]
        [Route("GetProjectDetails")]
        /*public async Task<ActionResult<Object>> GetProjectDetails([FromHeader] int id)*/
        public async Task<ActionResult<Object>> GetProjectDetails()
        {
            var id = 1;
            var project = _context.Projects.FirstOrDefault(p => p.Id == id);
            var users = _context.ProjectsUsers.Where(p => p.ProjectId == id).Select(u => u.UserId).ToArray();

            if (project != null)
            {
                return Ok(new
                {
                    project.Id,
                    project.Name,
                    assignedUserIds = _context.ProjectsUsers.Where(p => p.ProjectId == id).Select(u => u.UserId).ToArray()
                });
            }

            if (project == null)
            {
                return NotFound();
            }

            return Conflict();
        }

        #endregion GetProjectDetails

        //DOKOŃCZYĆ

        #region AddProject

        [HttpPost]
        [Authorize]
        [Route("AddProject")]
        //public async Task<IActionResult> AddProject(AddProjectModel model)
        public async Task<IActionResult> AddProject()
        {
            var project = new Project
            {
                // Id = 7,
                Name = "Hello",
                ProjectsUsers = null,
                Sprints = null
            };

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion AddProject
    }
}