using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Models.Projects.TaskEntities
{
    public class TaskType
    {
        public int TaskTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
