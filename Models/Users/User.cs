using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PlannerApi.Models
{
    public class User: IdentityUser
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //IdentityRole RoleId { get; set; }
        //public ICollection<ProjectUser> ProjectsUsers { get; set; }
    }
}
