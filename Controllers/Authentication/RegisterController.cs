using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PlannerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly ApplicationSettings _appSettings;

        #region Constructor
        public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }
        #endregion

        #region Register
        [HttpPost]
        //POST: api/Register
        public async Task<Object> PostAuthentication(UserRegisterModel model)
        {
            var newUser = new User()
            {
                UserName = model.UserName,
                Email = model.Email
            };
            try
            {
                var result = await _userManager.CreateAsync(newUser, model.Password);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
