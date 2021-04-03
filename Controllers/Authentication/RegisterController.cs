﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlannerApi.Models.Authentication;

namespace PlannerApi.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        #region Constructor
        public RegisterController(UserManager<User> userManager,  RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        #endregion Constructor

        #region Register

        [HttpPost]
        //POST: api/Register
        public async Task<Object> PostAuthentication(UserRegisterModel model)
        {
            var userExist = await _userManager.FindByNameAsync(model.UserName);

            if(userExist != null)
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
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed" });
            }

            if(!await _roleManager.RoleExistsAsync(UserRoles.Mannager))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Mannager));
            }
            if(!await _roleManager.RoleExistsAsync(UserRoles.Programmer))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Programmer));
            }
            if(!await _roleManager.RoleExistsAsync(UserRoles.Tester))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Tester));
            }
            await  _userManager.AddToRoleAsync(newUser, UserRoles.Programmer);

            return Ok(new Response { Status = "Success", Message = "User created succesfully" });
        }

        #endregion Register
    }
}