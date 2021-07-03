using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Models.TaskModel
{
    /// <summary>
    /// Kanban table's cell with specifically assigned tasks.
    /// </summary>
    public class KanbanCell
    {
        /// <summary>
        /// Status for assigned tasks
        /// </summary>
        public SimpleTaskStatus Status { get; set; }

        /// <summary>
        /// Task for assignment to the specific user with specific status
        /// </summary>
        public SimpleTask[] Tasks { get; set; }

    }
}
