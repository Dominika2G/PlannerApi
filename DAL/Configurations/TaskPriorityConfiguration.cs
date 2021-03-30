using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlannerApi.Models.Projects.TaskEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.DAL.Configurations
{
    public class TaskPriorityConfiguration: IEntityTypeConfiguration<TaskPriority>
    {
        public void Configure(EntityTypeBuilder<TaskPriority> builder)
        {
            builder
                .HasMany(tp => tp.Tasks)
                .WithOne(p => p.TaskPriority);
        }
    }
}
