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
using PlannerApi.Models.ProjectModels;

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

        #region DeleteProject
        [HttpDelete]
        [Authorize]
        [Route("DeleteProject/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);
            if (project == null)
            {
                return await Task.FromResult(NotFound());
            }

            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(Conflict());
        }

        #endregion DeleteProject

        #region GetProjectDetails
        [HttpGet]
        [Authorize]
        [Route("GetProjectDetails/{id}")]
        public async Task<ActionResult<Object>> GetProjectDetails(int id)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == id);
            var users = _context.ProjectsUsers.Where(p => p.ProjectId == id).Select(u => u.UserId).ToArray();

            if (project != null)
            {
                return await Task.FromResult(Ok(new
                {
                    project.Id,
                    project.Name,
                    assignedUserIds = _context.ProjectsUsers.Where(p => p.ProjectId == id).Select(u => u.UserId).ToArray()
                }));
            }

            if (project == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Conflict());
        }

        #endregion GetProjectDetails

        #region AddProject
        [HttpPost]
        [Authorize]
        [Route("AddProject")]
        public async Task<IActionResult> AddProject(AddProjectModel model)
        {
            var project = new Project
            {
                Name = model.Name,
            };

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            var projectId = _context.Projects.FirstOrDefault(p => p.Name == model.Name);
            foreach(var tmp in model.AssignedUserIds)
            {
                ProjectUser projUser = new ProjectUser();
                projUser.ProjectId = projectId.Id;
                projUser.UserId = tmp;
                await _context.ProjectsUsers.AddAsync(projUser);
            }
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion

        #region UpdateProject

        [HttpPut]
        [Authorize]
        [Route("UpdateProject")]
        public async Task<ActionResult> UpdateProject(UpdateProjectModel model){

            var existingProject = _context.Projects.FirstOrDefault(p => p.Id == model.Id);
            
            if(existingProject == null)
            {
                return NotFound();
            }

            existingProject.Name = model.Name;

            _context.Update(existingProject);
            _context.SaveChanges();

            var project = _context.Projects.SingleOrDefault(p => p.Name == model.Name);

            var listUserOfProject = _context.ProjectsUsers
                .Where(p => p.ProjectId == project.Id)
                .Select(p => p.UserId)
                .ToList();

            _context.ProjectsUsers.RemoveRange(_context.ProjectsUsers
                .Where(p => p.ProjectId == project.Id));

            await _context.SaveChangesAsync();

            foreach (var tmp in model.AssignedUserIds)
            {
                var projUser = new ProjectUser
                {
                    UserId = tmp,
                    ProjectId = project.Id
                };
                await _context.ProjectsUsers.AddAsync(projUser);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        #endregion
    }
}