using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlannerApi.Models.Projects;

namespace PlannerApi.DAL.Configurations
{
    public class CommentsConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder
                .HasOne(c => c.Task)
                .WithMany(t => t.CommentsList)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(c => c.TaskId);
        }
    }
}