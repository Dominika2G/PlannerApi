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
    public class ProjectsController : ControllerBase
    {
        #region Properties
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private DatabaseContext _context;
        #endregion

        #region Constructor
        public ProjectsController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, DatabaseContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        #endregion

        #region GetProjects
        [HttpGet]
        [Authorize]
        [Route("GetProjects")]
        public async Task<ActionResult<List<Object>>> GetProjects()
        {
            return Ok(_context.Projects.Select(p => new {
                    p.Id,
                    p.Name
                    }).ToArray());
        }
        #endregion

        #region DeleteProject
        /*[HttpDelete("{id}")]*/
        [HttpDelete("{id}")]
        [Authorize]
        [Route("DeleteProject")]
        /*public async Task<IActionResult> DeleteProject([FromBody] int id)*/
        public async Task<IActionResult> DeleteProject()
        {
            var id = 5;
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);
            //var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                NotFound();
            }

            if(project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
                return Ok();
            }

            return Conflict();
        }
        #endregion
    }
}
