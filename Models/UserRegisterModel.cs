using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Models
{
    public class UserRegisterModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
    }
}
