using System.Collections.Generic;

namespace PlannerApi.Models.Kanban
{
    /// <summary>
    /// Direct changes made in the kanban board and prepared for sending to WebAPI.
    /// </summary>
    public class KanbanChangesCollection
    {
        /// <summary>
        /// The singlest changes of Kanban board for persisiting in the database.
        /// </summary>
        public List<KanbanSingleChange> Changes { get; set; }

        /// <summary>
        /// A parameterless constructor for this class.
        /// </summary>
        public KanbanChangesCollection()
        {
            this.Changes = new List<KanbanSingleChange>();
        }
    }
}
