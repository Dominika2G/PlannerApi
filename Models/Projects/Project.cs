using System.Collections.Generic;


namespace PlannerApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProjectUser> ProjectsUsers { get; set; }

    }
}
