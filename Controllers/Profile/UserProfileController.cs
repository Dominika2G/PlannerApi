using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.DAL;
using PlannerApi.Models.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private DatabaseContext _context;
        #endregion

        #region Constructor
        public UserProfileController(UserManager<User> userManager, DatabaseContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
        #endregion

        #region UpdateOwnProfile
        [HttpPost]
        [Authorize]
        [Route("UpdateOwnProfile")]
        //PATCH: api/UserProfile/UpdateUser
        public async Task<IActionResult> UpdateOwnProfile(UpdateOwnProfile model)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            if(! string.IsNullOrEmpty(model.FirstName))
            {
                user.FirstName = model.FirstName;
            }
            if(!string.IsNullOrEmpty(model.LastName))
            {
                user.LastName = model.LastName;
            }
            if(!string.IsNullOrEmpty(model.Email))
            {
                user.Email = model.Email;
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok("");
            }

            return Conflict();
        }
        #endregion

        #region ChangeOwnPassword
        [HttpPost]
        [Authorize]
        [Route("UpdateOwnPassword")]
        public async Task<Object> UpdateOwuPassword(ChangePassword model)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                return Conflict();
            }

            return Ok("");

        }
        #endregion

        #region GetOwnProfile
        [HttpGet]
        [Authorize]
        [Route("GetOwnProfile")]
        public async Task<Object> GetOwnProfile()
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
                user.UserName,
                RoleName = userRole,
                user.FirstName,
                user.LastName,
                EmailAddress = user.Email
            });

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
                user.UserName,
                userRole,
                userId,
                accessToken = User.Identity.IsAuthenticated
                //accessToken = User.Claims.Select(x => x.Value)
            });
        }
        #endregion

        #region GetUsers
        [HttpGet]
        [Authorize]
        [Route("Users")]
        //GET: api/UserProfile/Users
        //public List<User> GetUsers() => _userManager.Users.ToList();
        //public ActionResult<IEnumerable<Object>> GetUsers()
        public async Task<ActionResult<List<Object>>> GetUsers()
        {
            List<UsersProfile> listOfUsers = new List<UsersProfile>();
            var list = _userManager.Users.ToList();
      
            foreach(var tmp in list)
            {
                var role = await _userManager.GetRolesAsync(tmp);
                var userRole = role.FirstOrDefault();
                var user = new UsersProfile(
                    tmp.Id,
                    tmp.FirstName,
                    tmp.LastName,
                    tmp.Email,
                    userRole,
                    tmp.UserName
                );
                listOfUsers.Add(user);
            }
            if(listOfUsers != null)
            {
                return Ok(listOfUsers);
            }
            return NoContent();
        }
        #endregion

        #region GetUserDetails
        [HttpGet("{id}")]
        //[HttpGet]
        [Authorize]
        [Route("UserDetails")]
        //GET: api/UserProfile/UserDetails/{id}
        public async Task<Object> GetUserDetails(string id)
        //public async Task<Object> GetUserDetails()
        {
            //var id = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9";
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                var role = await _userManager.GetRolesAsync(user);
                var userRole = role.FirstOrDefault();
                var roleByManager = await _roleManager.FindByNameAsync(userRole);
                var roleId = roleByManager.Id;
                return Ok(new
                {
                    user.Id,
                    user.UserName,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.PasswordHash,
                    roleId
                });
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
                roleName = role.Name,
                role.Id
            }).ToList());
        }
        #endregion

        #region DeleteUser
        [HttpDelete("{id}")]
        //[HttpDelete]
        [Route("User")]
        [Authorize]
        //DELETE: api/UserProfile/DeleteUser
        //public async Task<IActionResult> DeleteUser()
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if(user == null)
            {
                return NotFound();
            }
            var role = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, role);
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
            var role = await _roleManager.FindByIdAsync(model.Role);

            await _userManager.AddToRoleAsync(newUser, role.Name);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status409Conflict, new Response { Status = "Error", Message = "User creation failed" });
            }

            return Ok(new Response { Status = "Success", Message = "User created succesfully" });
        }
        #endregion

        #region UpdateUser
        [HttpPut]
        [Authorize]
        [Route("UpdateUser")]
        //PATCH: api/UserProfile/UpdateUser
        public async Task<IActionResult> PuthUser(UserDetails user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if(existingUser == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(user.UserName))
            {
                existingUser.UserName = user.UserName;
            }
            if(!string.IsNullOrEmpty(user.FirstName))
            {
                existingUser.FirstName = user.FirstName;
            }
            if(!string.IsNullOrEmpty(user.LastName))
            {
                existingUser.LastName = user.LastName;
            }
            if(!string.IsNullOrEmpty(user.NewPassword) && !string.IsNullOrEmpty(user.OldPassword))
            {
                await _userManager.ChangePasswordAsync(existingUser, user.OldPassword, user.NewPassword);
            }
            if(!string.IsNullOrEmpty(user.RoleId))
            {
                var role = await _userManager.GetRolesAsync(existingUser);
                var userRole = role.FirstOrDefault();
                await _userManager.RemoveFromRoleAsync(existingUser, userRole);
                var findRole = await _roleManager.FindByIdAsync(user.RoleId);

                await _userManager.AddToRoleAsync(existingUser, findRole.Name);
            }
            if(!string.IsNullOrEmpty(user.Email))
            {
                existingUser.Email = user.Email;
            }

            var result = await _userManager.UpdateAsync(existingUser);
            if (result.Succeeded)
            {
                return Ok("");
            }

            return Conflict();
        }
        #endregion
    }

}
