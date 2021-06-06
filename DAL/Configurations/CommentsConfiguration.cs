using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlannerApi.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.DAL.Configurations
{
    public class CommentsConfiguration: IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder
                .HasOne(c => c.Task)
                .WithMany(t => t.CommentsList)
                .HasForeignKey(c => c.TaskId);
        }
    }
}
