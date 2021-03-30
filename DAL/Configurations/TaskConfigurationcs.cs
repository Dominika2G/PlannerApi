using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlannerApi.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PlannerApi.DAL.Configurations
{
    public class TaskConfigurationcs: IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.TaskPriority)
                .WithMany(tp => tp.Tasks);

            builder
                .HasOne(t => t.TaskStatus)
                .WithMany(t => t.Tasks);

            builder
                .HasOne(t => t.TaskType)
                .WithMany(t => t.Tasks);

            builder
                .HasOne(t => t.Sprint)
                .WithMany(s => s.Tasks);
        }
    }
}
