using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlannerApi.Models;

namespace PlannerApi.DAL.Configurations
{
    public class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
    {
        public void Configure(EntityTypeBuilder<ProjectUser> builder)
        {
            builder
                .HasKey(pu => new { pu.UserId, pu.ProjectId });
            builder
                .HasOne(pu => pu.User)
                .WithMany(pu => pu.ProjectsUsers)
                .HasForeignKey(pu => pu.UserId);
            builder
                .HasOne(pu => pu.Project)
                .WithMany(p => p.ProjectsUsers)
                .HasForeignKey(pu => pu.ProjectId);
        }
    }
}