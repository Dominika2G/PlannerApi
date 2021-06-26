
using PlannerApi.Models.Pagination;

namespace PlannerApi.Models.TaskModel
{
    /// <summary>
    /// Simple class used for getting data about tasks of specified sprint.
    /// </summary>
    public class SimpleSprintWithTasks
    {
        /// <summary>
        /// Page of tasks of this sprint
        /// </summary>
        public DataPage<SimpleTask> PageOfTasks { get; set; }

        /// <summary>
        /// ID of the project the tasks are assigned for
        /// </summary>
        public int? ProjectId { get; set; }

        /// <summary>
        /// Name of the proejct the tasks are assigned for
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Name of the sprint the tasks are assigned for
        /// </summary>
        public string SprintName { get; set; }
    }
}
