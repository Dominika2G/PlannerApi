using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Models.TaskModel
{
    /// <summary>
    /// Row of tasks with their current statuses.
    /// </summary>
    public class KanbanRow
    {
        /// <summary>
        /// The user whom tasks are assigned to.
        /// </summary>
        public SimpleEnlistedUser Assignee { get; set; }

        /// <summary>
        /// Cells for Kanban board. Every cell has a designated status type.
        /// </summary>
        public KanbanCell[] TaskCells { get; set; }
    }
}
