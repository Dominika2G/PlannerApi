using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlannerApi.Models.Projects;

namespace PlannerApi.DAL.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Sprint)
                .WithMany(s => s.Tasks)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(t => t.SprintId);
        }
    }
}