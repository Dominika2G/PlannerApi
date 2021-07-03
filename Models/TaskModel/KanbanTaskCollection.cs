namespace PlannerApi.Models.TaskModel
{
    /// <summary>
    /// Details of assigning task for the kanban board.
    /// </summary>
    public class KanbanTaskCollection
    {
        public int SprintId { get; set; }

        public string[] AllowedStatusNames { get; set; }

        public KanbanRow[] TaskRows { get; set; }
    }
}