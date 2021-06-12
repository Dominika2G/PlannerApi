using PlannerApi.Models.Authentication;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlannerApi.Models.Projects
{
    public class Comments
    {
        public int CommentsId { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}