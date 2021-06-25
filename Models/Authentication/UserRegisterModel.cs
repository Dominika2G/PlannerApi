using System;
using System.ComponentModel.DataAnnotations;

namespace PlannerApi.Models.Authentication
{
    public class UserRegisterModel
    {
        public String UserName { get; set; }

        public String Password { get; set; }

        public String EmailAddress { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
    }
}
