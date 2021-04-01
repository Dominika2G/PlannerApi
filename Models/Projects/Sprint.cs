using System;

namespace PlannerApi.Models
{
    public class Sprint
    {
        public int SprintId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}