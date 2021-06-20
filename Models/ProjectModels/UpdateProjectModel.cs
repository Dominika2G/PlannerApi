using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.Models.ProjectModels
{
    public class UpdateProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> AssignedUserIds { get; set; }
    }
}
