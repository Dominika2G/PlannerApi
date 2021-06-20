using System;
using System.Collections.Generic;
using PlannerApi.Models.Projects;

namespace PlannerApi.Models
{
    public class Sprint
    {
        public int SprintId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}