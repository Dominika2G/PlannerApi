namespace PlannerApi.Models.TaskModel
{
    /// <summary>
    /// Class used in listings of users. Only basic and unmanageable data provided.
    /// </summary>
    public class SimpleEnlistedUser
    {
        /// <summary>
        /// ID of the user
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }
    }
}
