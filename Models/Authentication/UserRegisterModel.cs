using System;
using System.ComponentModel.DataAnnotations;

namespace PlannerApi.Models.Authentication
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
