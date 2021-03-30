using PlannerApi.Models.Projects;
using System.Collections.Generic;

namespace PlannerApi.Models.Projects.TaskEntities
{
    public class TaskPriority
    {
        public int TaskPriorityId { get; set; }
        public string Name { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
