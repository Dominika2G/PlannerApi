namespace PlannerApi.Models.TaskModel
{
    /// <summary>
    /// Class containing basic status for a single task.
    /// </summary>
    public class SimpleTaskStatus
    {
        /// <summary>
        /// Database ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of a task status
        /// </summary>
        public string StatusName { get; set; }
    }
}
