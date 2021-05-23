using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Models.Authentication
{
    public class UsersProfile
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public UsersProfile() { }
        public UsersProfile(string _Id, string _FirstName, string _LastName, string _Email, string _RoleName, string _Username)
        {
            Id = _Id;
            FirstName = _FirstName;
            LastName = _LastName;
            Email = _Email;
            RoleName = _RoleName;
            UserName = _Username;
        }
    }
}
