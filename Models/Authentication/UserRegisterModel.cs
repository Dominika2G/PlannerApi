using System;
using System.ComponentModel.DataAnnotations;

namespace PlannerApi.Models.Authentication
{
    public class UserRegisterModel
    {
        public String UserName { get; set; }

        public String Password { get; set; }

        public String Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
