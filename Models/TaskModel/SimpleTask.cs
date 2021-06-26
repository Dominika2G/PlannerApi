namespace PlannerApi.Models.TaskModel
{
    /// <summary>
    /// Data for simple and unmanageable data for a single task.
    /// </summary>
    public class SimpleTask
    {
        /// <summary>
        /// ID of the task
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the task
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Task's description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Name of user reporting (creating) the task
        /// </summary>
        public string ReporterName { get; set; }
        /// <summary>
        /// Name of user whom the task is assigned for
        /// </summary>
        public string AssigneeName { get; set; }
        /// <summary>
        /// Name of sprint which the task is assigned for
        /// </summary>
        public string SprintName { get; set; }
        /// <summary>
        /// Database ID of the sprint the task is assigned for
        /// </summary>
        public int SprintId { get; set; }
        /// <summary>
        /// Name of task type
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Name of task's progress status
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// Task's priority name
        /// </summary>
        public string PriorityName { get; set; }
        /// <summary>
        /// Estimate time of task. The time is expressed in hours.
        /// </summary>
        public int EstimatedTime { get; set; }
    }
}
