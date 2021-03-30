using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlannerApi.Models;
using PlannerApi.Models.Projects;
using PlannerApi.Models.Projects.TaskEntities;

namespace PlannerApi.DAL
{
    public class DatabaseContext : IdentityDbContext
    {
        public  DbSet<User> Users { get; set; }
        /*public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectsUsers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskPriority> TaskPriorities { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        */
        public DatabaseContext(DbContextOptions options): base(options) { }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //*********** ProjectUser **************
            modelBuilder.Entity<ProjectUser>()
                .HasKey(pu => new { pu.UserId, pu.ProjectId });
            modelBuilder.Entity<ProjectUser>()
                .HasOne(pu => pu.User)
                .WithMany(pu => pu.ProjectsUsers)
                .HasForeignKey(pu => pu.UserId);
            modelBuilder.Entity<ProjectUser>()
                .HasOne(pu => pu.Project)
                .WithMany(p => p.ProjectsUsers)
                .HasForeignKey(pu => pu.ProjectId);

            //*********** TaskPriorities **************
            modelBuilder.Entity<TaskPriority>()
                .HasMany(tp => tp.Tasks)
                .WithOne(p => p.TaskPriority);

            //**************** Task *******************
            modelBuilder.Entity<Task>()
                .HasOne(t => t.TaskPriority)
                .WithMany(tp => tp.Tasks);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.TaskStatus)
                .WithMany(t => t.Tasks);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.TaskType)
                .WithMany(t => t.Tasks);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Sprint)
                .WithMany(s => s.Tasks);

            //************* TaskStatus ****************
            modelBuilder.Entity<TaskStatus>()
                .HasMany(ts => ts.Tasks)
                .WithOne(p => p.TaskStatus);

            //************** TaskType *****************
            modelBuilder.Entity<TaskType>()
                .HasMany(tt => tt.Tasks)
                .WithOne(t => t.TaskType);

            //**************** Sprint *******************
            modelBuilder.Entity<Sprint>()
                .HasMany(s => s.Tasks)
                .WithOne(t => t.Sprint);

        }*/

    }
}
