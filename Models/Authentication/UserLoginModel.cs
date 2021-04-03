using System.ComponentModel.DataAnnotations;

namespace PlannerApi.Models.Authentication
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "UserName is required")]
        [MinLength(4), MaxLength(25)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is rewuired")]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
