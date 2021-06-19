using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.DAL;
using PlannerApi.Models.Authentication;

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

        [HttpDelete]
        [Authorize]
        [Route("DeleteSprint")]
        /*public async Task<IActionResult> DeleteProject([FromBody] int id)*/
        public async Task<IActionResult> DeleteTask()
        {
            var id = 2;
            var project = _context.Sprints.FirstOrDefault(x => x.SprintId == id);
            //var project = await _context.Projects.FindAsync(id);
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
    }
}