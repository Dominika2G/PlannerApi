﻿using System;
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

        [HttpDelete("{id}")]
        /*[HttpDelete]*/
        [Authorize]
        [Route("DeleteProject")]
        public async Task<IActionResult> DeleteProject([FromBody] int id)
        /*public async Task<IActionResult> DeleteProject()*/
        {
            /*var id = 1;*/
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);
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

        //DODAWANIE PROJEKTÓW DZIAŁA ALE BEZ USERÓW
        //DOKOŃCZYĆ DODAĆ USERÓW
        #region AddProject

        [HttpPost]
        [Authorize]
        [Route("AddProject")]
        //public async Task<IActionResult> AddProject(AddProjectModel model)
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

        //UPDATE DZIAŁA ALE BEZ USERÓW
        //DODAĆ UPDATE USERÓW
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

            return Ok();

        }

        #endregion
    }
}