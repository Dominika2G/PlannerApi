using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlannerApi.DAL.Configurations;
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
            modelBuilder.ApplyConfiguration(new ProjectUserConfiguration());
            modelBuilder.ApplyConfiguration(new TaskPriorityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfigurationcs());
            modelBuilder.ApplyConfiguration(new TaskStatusConfiguration());
            modelBuilder.ApplyConfiguration(new TaskTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SprintConfiguration());

        }*/

    }
}
