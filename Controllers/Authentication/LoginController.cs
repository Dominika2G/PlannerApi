using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlannerApi.Models;
using PlannerApi.Models.Authentication;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApi.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Properties
        private UserManager<User> _userManager;
        private readonly ApplicationSettings _appSettings;
        #endregion

        #region Constructor
        public LoginController(UserManager<User> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }
        #endregion

        #region Login
        [HttpPost]
        //POST: api/Login
        public async Task<IActionResult> PostLogin(UserLoginModel model)
        {
            var currentUser = await _userManager.FindByNameAsync(model.UserName);

            if (currentUser != null && await _userManager.CheckPasswordAsync(currentUser, model.Password))
            {
                var role = await _userManager.GetRolesAsync(currentUser);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("UserID", currentUser.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT)), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescription);
                var accessToken = tokenHandler.WriteToken(securityToken);
                var userRole = role.FirstOrDefault();
                
                return Ok(new
                {
                    accessToken,
                    currentUser.UserName,
                    userRole
                });
            }
            else
            {
                return BadRequest(new { message = "Password or login is incorrect" });
            }
        }
        #endregion
    }

}
