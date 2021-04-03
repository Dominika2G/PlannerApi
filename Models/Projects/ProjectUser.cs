using PlannerApi.Models.Authentication;

namespace PlannerApi.Models
{
    public class ProjectUser
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}