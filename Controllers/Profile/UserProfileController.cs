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
            var role = await _userManager.GetRolesAsync(user);
            var userRole = role.FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                //user.FirstName,
                //user.Email,
                user.UserName,
                userRole,
                userId
            });
        }
        #endregion

        #region GetUsers
        [HttpGet]
        [Authorize]
        [Route("Users")]
        //GET: api/UserProfile/Users
        //public List<User> GetUsers() => _userManager.Users.ToList();
        public ActionResult<IEnumerable<Object>> GetUsers()
        {
            /*IEnumerable<UsersProfile> listOfUsers = null;
            foreach(var tmp in _userManager.Users)
            {
                var role = await _userManager.GetRolesAsync(tmp);
                var userRole = role.FirstOrDefault();
                listOfUsers.Append(new UsersProfile(
                    tmp.Id,
                    tmp.FirstName,
                    tmp.LastName,
                    tmp.Email,
                    userRole
                ));
            }
            return listOfUsers;*/
            
            return  Ok(_userManager.Users.Select(user => new
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

        #region AddUser
        [HttpPost]
        [Authorize]
        [Route("AddUser")]
        //POST: api/UserProfile/AddUser
        public async Task<Object> PostAddUser(UserRegisterModel model)
        {
            //model.Role = "Programmer";
            var userExist = await _userManager.FindByNameAsync(model.UserName);

            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exist" });
            }

            var newUser = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            var role = _context.Roles.Find(model.Role);
            
            await _userManager.AddToRoleAsync(newUser, role.Name);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed" });
            }

            return Ok(new Response { Status = "Success", Message = "User created succesfully" });
        }
        #endregion
    }
}
