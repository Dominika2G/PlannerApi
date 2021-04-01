using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PlannerApi.Models
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<ProjectUser> ProjectsUsers { get; set; }
    }
}