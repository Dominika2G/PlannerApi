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

namespace PlannerApi.Controllers.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        #region Properties
        private readonly UserManager<User> _userManager;
        private DatabaseContext _context;
        #endregion

        #region Constructor
        public UserProfileController(UserManager<User> userManager, DatabaseContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        #endregion

        #region PostUserProfile
        [HttpPost]
        [Authorize]
        //POST: api/UserProfile
        public async Task<Object> PostUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                user.FirstName,
                user.Email,
                user.UserName
            });
        }
        #endregion

        #region GetUsers
        [HttpGet]
        [Authorize]
        [Route("Users")]
        //GET: api/UserProfile/Users
        //public List<User> GetUsers() => _userManager.Users.ToList();
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userManager.Users.Select(user => new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.UserName,
                user.Id
            }).ToList());
        }
        #endregion

        #region GetUserDetails
        [HttpGet("{id}")]
        [Authorize]
        [Route("UserDetails")]
        //GET: api/UserProfile/UserDetails/{id}
        public async Task<Object> GetUserDetails(string id)
        {
            //var id = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9";
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        #endregion

        #region GetRoles
        [HttpGet]
        [Authorize]
        [Route("Roles")]
        //GET: /api/UserProfile/Roles
        public ActionResult<IEnumerable<IdentityRole>> GetRoles()
        {
            return Ok(_context.Roles.Select(role => new
            {
                role.Name
            }).ToList());
        }
        #endregion

        #region DeleteUser
        [HttpDelete("{id}")]
        [Route("User")]
        [Authorize]
        //DELETE: api/UserProfile/DeleteUser
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if(user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok("");
            }

            return Conflict();
        }
        #endregion
    }
}
