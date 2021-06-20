using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Models.TaskModel
{
    public class CommentModel
    {
        public int TaskId { get; set; }
        public string CommentContent { get; set; }
    }
}
