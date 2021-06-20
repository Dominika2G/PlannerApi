using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Models.TaskModel
{
    public class CreateTaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EstimatedTime { get; set; }
        public int? TaskPriorityId { get; set; }
        public int? TaskStatusId { get; set; }
        public int? TaskTypeId { get; set; }
        public int? SprintId { get; set; }
        public string AssigneedId { get; set; }

    }
}
