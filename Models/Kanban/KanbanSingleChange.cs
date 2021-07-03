namespace PlannerApi.Models.Kanban
{
    /// <summary>
    /// The class for containing the singlest change in Kanban board.
    /// </summary>
    public class KanbanSingleChange
    {
        /// <summary>
        /// Database ID of the task that will have assignings changed.
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Database ID of the user that will get the task assigned.
        /// </summary>
        public string AssignedUserId { get; set; }

        /// <summary>
        /// Desired status for the task.
        /// </summary>
        public int SetStatusId { get; set; }
    }
}
