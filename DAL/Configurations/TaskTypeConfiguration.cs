using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlannerApi.Models.Projects.TaskEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.DAL.Configurations
{
    public class TaskTypeConfiguration: IEntityTypeConfiguration<TaskType>
    {
        public void Configure(EntityTypeBuilder<TaskType> builder)
        {
            builder
                .HasMany(tt => tt.Tasks)
                .WithOne(t => t.TaskType);
        }
    }
}
