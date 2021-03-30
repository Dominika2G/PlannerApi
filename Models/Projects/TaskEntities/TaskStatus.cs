using PlannerApi.Models.Projects;
using System.Collections.Generic;

namespace PlannerApi.Models.Projects.TaskEntities
{
    public class TaskStatus
    {
        public int TaskStatusId { get; set; }
        public string TaskName { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
