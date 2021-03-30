

using PlannerApi.Models.Projects;
using System.Collections.Generic;

namespace PlannerApi.Models
{
    public class Sprint
    {
        public int SprintId { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
