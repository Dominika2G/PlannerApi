using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Models.ProjectModels
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> AssignedUserIds { get; set; } 
        public ICollection<Sprint> Sprints { get; set; }
    }
}
