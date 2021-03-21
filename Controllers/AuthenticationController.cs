using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        //POST: api/Authentication/Register
        public async Task<Object> PostAuthentication(UserRegisterModel model)
        {
            var newUser = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };
            try
            {
                var result = await _userManager.CreateAsync(newUser, model.Password);
                return Ok(result);

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
