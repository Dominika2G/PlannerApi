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
        public int? EstimatedTime { get; set; }
        public int? PriorityId { get; set; }
        public int? StatusId { get; set; }
        public int? TaskTypeId { get; set; }
        public int? SprintId { get; set; }
        public string AssigneeId { get; set; }

    }
}
