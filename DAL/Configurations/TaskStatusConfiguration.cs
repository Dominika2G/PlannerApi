using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlannerApi.Models.Projects.TaskEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlannerApi.DAL.Configurations
{
    public class TaskStatusConfiguration: IEntityTypeConfiguration<TaskStatus>
    {
        public void Configure(EntityTypeBuilder<TaskStatus> builder)
        {
            builder
                .HasMany(ts => ts.Tasks)
                .WithOne(p => p.TaskStatus);
        }
    }
}
