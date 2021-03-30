using PlannerApi.Models.Projects.TaskEntities;

namespace PlannerApi.Models.Projects
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EstimatedTime { get; set; }

        public TaskPriority TaskPriority { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public TaskType TaskType { get; set; }
        public Sprint Sprint { get; set; }

        //ReportedId
        //AssignedId
    }
}
