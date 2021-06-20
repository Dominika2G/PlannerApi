using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.DAL;
using PlannerApi.Models;
using PlannerApi.Models.Authentication;
using PlannerApi.Models.SprintModel;

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

        #endregion Properties

        #region Constructor

        public SprintsController(UserManager<User> usermanager, RoleManager<IdentityRole> roleManager, DatabaseContext context)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _context = context;
        }

        #endregion Constructor

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
                    Users = _context.ProjectsUsers.Where(p => p.ProjectId == id).Select(u => new
                    {
                        u.UserId,
                        u.User.UserName
                    }).ToArray(),
                    Sprints = _context.Sprints.Where(p => p.ProjectId == id).Select(s => new
                    {
                        s.SprintId,
                        s.Name,
                        StartTime = s.StartDate,
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

        #endregion GetProjectsWithSprints

        #region DeleteSprint

        /*[HttpDelete]*/
        [HttpDelete("{id}")]
        [Authorize]
        [Route("DeleteSprint")]
        /*public async Task<IActionResult> DeleteSprint([FromBody] int id)*/
        public async Task<IActionResult> DeleteSprint([FromBody] int id)
        {
            /*var id = 2;*/
            var project = _context.Sprints.FirstOrDefault(x => x.SprintId == id);
            if (project == null)
            {
                NotFound();
            }

            if (project != null)
            {
                _context.Sprints.Remove(project);
                _context.SaveChanges();
                return Ok();
            }

            return Conflict();
        }

        #endregion

        //DODAWANIE SPRINTU ZROBIONE ANALOGICZNIE JAK W PROJEKTACH, ALE W POSTMANIE WYSKAKUJE BŁĄD
        //DO POPRAWY
        #region AddSprint

        [HttpPost]
        [Authorize]
        [Route("AddSprint")]
        //public async Task<IActionResult> AddProject(AddProjectModel model)
        public async Task<IActionResult> AddSprint(AddSprintModel model)
        {
            var sprint = new Sprint
            {
                //SprintId = model.Id,
                Name = model.Name,
                StartDate = model.StartTime,
                EndDate = model.EndTime
            };

            await _context.Sprints.AddAsync(sprint);
            await _context.SaveChangesAsync();

            return Ok();
        }


        #endregion

        //DODAWANIE TASKA DZIAŁA, TRZEBA JESZCZE TYLKO SPRAWDZIĆ CZY DATETIME JEST CZY NIE ZOSTAŁ PODANY
        #region UpdateSprint
        [HttpPut]
        [Authorize]
        [Route("UpdateSprint")]
        public async Task<ActionResult> UpdateSprint(UpdateSprintModel model)
        {
            var existingSprint = _context.Sprints.FirstOrDefault(s => s.SprintId == model.Id);

            if(existingSprint == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                existingSprint.Name = model.Name;
            }

            existingSprint.StartDate = model.StartTime;
            existingSprint.EndDate = model.EndTime;

            _context.Sprints.Update(existingSprint);
            _context.SaveChanges();

            return Ok();
        }
        #endregion

    }
}