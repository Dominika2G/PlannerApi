using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private UserManager<User> _userManager;

        public PasswordController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> ChangePassword(ChangePasswordModel model)
        {
           // var userId = _userService.GetUserId();
        }
    }
}
