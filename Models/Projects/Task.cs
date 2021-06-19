using System.Collections.Generic;
using PlannerApi.Models.Authentication;
using PlannerApi.Models.Projects.TaskEntities;

namespace PlannerApi.Models.Projects
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EstimatedTime { get; set; }

        public int TaskPriorityId { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public int TaskStatusId { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int TaskTypeId { get; set; }
        public TaskType TaskType { get; set; }
        public int? SprintId { get; set; }
        public Sprint? Sprint { get; set; }
        public string ReporterId { get; set; }
        public User Reporter { get; set; }
        public string AssigneeId { get; set; }
        public User Assignee { get; set; }
        public ICollection<Comments> CommentsList { get; set; }
    }
}