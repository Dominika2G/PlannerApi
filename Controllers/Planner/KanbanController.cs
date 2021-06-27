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
    public class KanbanController : ControllerBase
    {
        #region Properties

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private DatabaseContext _context;

        #endregion Properties

        #region Constructor
        public KanbanController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, DatabaseContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        #endregion

        #region GetTasks
        [HttpGet]
        [Authorize]
        [Route("GetTasks")]
        /*public ActionResult GetTasks()
        {

        }*/
        #endregion

        #region GetTasks/id
        [HttpGet]
        [Authorize]
        [Route("GetTasks/{id}")]
        #endregion

        #region GetCurrentSprints
        [HttpGet]
        [Authorize]
        [Route("GetCurrentSprints")]
        #endregion

        #region SetChanges
        [HttpPost]
        [Authorize]
        [Route("SetChanges")]
        #endregion
    }
}
