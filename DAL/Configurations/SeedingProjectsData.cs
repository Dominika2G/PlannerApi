using Microsoft.EntityFrameworkCore;
using PlannerApi.Models;
using PlannerApi.Models.Projects;
using PlannerApi.Models.Projects.TaskEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlannerApi.DAL.Configurations
{
    public static class SeedingProjectsData
    {
        public static void Seed2(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "Cryptowallet"
                },
                new Project
                {
                    Id = 2,
                    Name = "Darknet AI"
                },
                new Project
                {
                    Id = 3,
                    Name = "Steam 2.0"
                },
                new Project
                {
                    Id = 4,
                    Name = "Polsl galaxy"
                },
                new Project
                {
                    Id = 5,
                    Name = "Some random stuff"
                }
            );

            modelBuilder.Entity<TaskStatus>().HasData(
                new TaskStatus
                {
                    TaskStatusId = 1,
                    TaskName = "New"
                },
                new TaskStatus
                {
                    TaskStatusId = 2,
                    TaskName = "In progress"
                },
                new TaskStatus
                {
                    TaskStatusId = 3,
                    TaskName = "Pending"
                },
                new TaskStatus
                {
                    TaskStatusId = 4,
                    TaskName = "Testing"
                },
                new TaskStatus
                {
                    TaskStatusId = 5,
                    TaskName = "Reply"
                }
            );

            modelBuilder.Entity<TaskPriority>().HasData(
                new TaskPriority
                {
                    TaskPriorityId = 1,
                    Name = "Low"
                },
                new TaskPriority
                {
                    TaskPriorityId = 2,
                    Name = "Normal"
                },
                new TaskPriority
                {
                    TaskPriorityId = 3,
                    Name = "High"
                },
                new TaskPriority
                {
                    TaskPriorityId = 4,
                    Name = "Urgent"
                },
                new TaskPriority
                {
                    TaskPriorityId = 5,
                    Name = "IMMEDIATE"
                }
            );

            modelBuilder.Entity<TaskType>().HasData(
                new TaskType
                {
                    TaskTypeId = 1,
                    Name = "Task"
                },
                new TaskType
                {
                    TaskTypeId = 2,
                    Name = "Error"
                },
                new TaskType
                {
                    TaskTypeId = 3,
                    Name = "Proposal"
                }
            );

            modelBuilder.Entity<Sprint>().HasData(
                new Sprint
                {
                    SprintId = 1,
                    Name = "Sprint 1",
                    StartDate = new DateTime(2021, 3, 2),
                    EndDate = new DateTime(2021, 3, 15)
                },
                new Sprint
                {
                    SprintId = 2,
                    Name = "Sprint 2",
                    StartDate = new DateTime(2021, 2, 16),
                    EndDate = new DateTime(2021, 3, 1)
                },
                new Sprint
                {
                    SprintId = 3,
                    Name = "Sprint 3",
                    StartDate = new DateTime(2021, 1, 31),
                    EndDate = new DateTime(2021, 2, 15)
                },
                new Sprint
                {
                    SprintId = 4,
                    Name = "Sprint 4",
                    StartDate = new DateTime(2021, 1, 16),
                    EndDate = new DateTime(2021, 1, 30)
                },
                new Sprint
                {
                    SprintId = 5,
                    Name = "Sprint 5",
                    StartDate = new DateTime(2021, 1, 1),
                    EndDate = new DateTime(2021, 1, 15)
                }
            );

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    TaskId = 1,
                    Name = "Task 1",
                    Description = "Task 1 description",
                    EstimatedTime = "10",
                    TaskPriorityId = 1,
                    TaskStatusId = 1,
                    TaskTypeId = 2,
                    SprintId =1,
                    ReporterId = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                    AssigneeId = "220c495c-95f9-411d-aa86-6b96c2778765"
                },
                new Task
                {
                    TaskId = 2,
                    Name = "Task 2",
                    Description = "Task 2 description",
                    EstimatedTime = "16",
                    TaskPriorityId = 2,
                    TaskStatusId = 3,
                    TaskTypeId = 2,
                    SprintId = 2,
                    ReporterId = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                    AssigneeId = "877a0a41-23b3-4511-89f5-13d1cd5b750a"
                }
            );

            modelBuilder.Entity<ProjectUser>().HasData(
                new ProjectUser
                {
                    UserId = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                    ProjectId = 1
                },
                new ProjectUser
                {
                    UserId = "220c495c-95f9-411d-aa86-6b96c2778765",
                    ProjectId = 1
                },
                new ProjectUser
                {
                    UserId = "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                    ProjectId = 1
                },
                new ProjectUser
                {
                    UserId = "72546802-9b55-4a9c-9a4e-50bac18a0028",
                    ProjectId = 2
                },
                new ProjectUser
                {
                    UserId = "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                    ProjectId = 2
                }
            );

            modelBuilder.Entity<Comments>().HasData(
                new Comments
                {
                    CommentsId = 1,
                    AuthorId = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                    StartDate = new DateTime(2021, 05, 12, 12, 0, 0),
                    TaskId = 1,
                    Content = "Some random stuff goes here."
                },
                new Comments
                {
                    CommentsId = 2,
                    AuthorId = "220c495c-95f9-411d-aa86-6b96c2778765",
                    StartDate = new DateTime(2021, 05, 13, 9, 35, 0),
                    TaskId = 2,
                    Content = "Pretty neat!"
                },
                new Comments
                {
                    CommentsId = 3,
                    AuthorId = "72546802-9b55-4a9c-9a4e-50bac18a0028",
                    StartDate = new DateTime(2021, 05, 18, 14, 02, 0),
                    TaskId = 1,
                    Content = "Cumque qui odit consequatur provident molestiae qui voluptas.Vitae autem et consequatur ipsum.Quis ipsum exercitationem natus velit.Ut qui eum sint magnam doloremque. " +
                            "Voluptatibus enim non rerum facilis numquam ea error numquam.Quas et non eligendi a reprehenderit libero et assumenda."
                }
            );

        }
    }
}
