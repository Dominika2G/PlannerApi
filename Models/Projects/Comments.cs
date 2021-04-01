using System;
using System.ComponentModel.DataAnnotations;

namespace PlannerApi.Models.Projects
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}