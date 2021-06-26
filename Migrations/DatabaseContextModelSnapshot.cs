﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlannerApi.DAL;

namespace PlannerApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "222667d9-4543-498e-948a-5fc1c2dc2d62",
                            ConcurrencyStamp = "2420f8b1-58d7-49a7-8e44-7228b415b93a",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "471cd850-b05f-46ef-9c3b-5785ba3fadcd",
                            ConcurrencyStamp = "85cadb0c-05e9-4f65-8786-e33e35403468",
                            Name = "Programmer",
                            NormalizedName = "PROGRAMMER"
                        },
                        new
                        {
                            Id = "b83721c8-b13c-4f4e-89a9-7797c4ed0c85",
                            ConcurrencyStamp = "92265458-1b6a-4a35-99bd-39feda4d1d7a",
                            Name = "Tester",
                            NormalizedName = "TESTER"
                        },
                        new
                        {
                            Id = "b585f129-1abe-44f9-90a9-1e5d354973cb",
                            ConcurrencyStamp = "0f602014-30b7-4e62-b18d-c16ad06ddaae",
                            Name = "Unauthorize",
                            NormalizedName = "UNAUTHORIZE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "220c495c-95f9-411d-aa86-6b96c2778765",
                            RoleId = "471cd850-b05f-46ef-9c3b-5785ba3fadcd"
                        },
                        new
                        {
                            UserId = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                            RoleId = "222667d9-4543-498e-948a-5fc1c2dc2d62"
                        },
                        new
                        {
                            UserId = "72546802-9b55-4a9c-9a4e-50bac18a0028",
                            RoleId = "222667d9-4543-498e-948a-5fc1c2dc2d62"
                        },
                        new
                        {
                            UserId = "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                            RoleId = "b83721c8-b13c-4f4e-89a9-7797c4ed0c85"
                        },
                        new
                        {
                            UserId = "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3",
                            RoleId = "471cd850-b05f-46ef-9c3b-5785ba3fadcd"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PlannerApi.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cryptowallet"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Darknet AI"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Steam 2.0"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Polsl galaxy"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Some random stuff"
                        });
                });

            modelBuilder.Entity("PlannerApi.Models.ProjectUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectsUsers");

                    b.HasData(
                        new
                        {
                            UserId = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                            ProjectId = 1
                        },
                        new
                        {
                            UserId = "220c495c-95f9-411d-aa86-6b96c2778765",
                            ProjectId = 1
                        },
                        new
                        {
                            UserId = "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                            ProjectId = 1
                        },
                        new
                        {
                            UserId = "72546802-9b55-4a9c-9a4e-50bac18a0028",
                            ProjectId = 2
                        },
                        new
                        {
                            UserId = "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                            ProjectId = 2
                        });
                });

            modelBuilder.Entity("PlannerApi.Models.Projects.Comments", b =>
                {
                    b.Property<int>("CommentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("CommentsId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TaskId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentsId = 1,
                            AuthorId = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                            Content = "Some random stuff goes here.",
                            StartDate = new DateTime(2021, 5, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskId = 1
                        },
                        new
                        {
                            CommentsId = 2,
                            AuthorId = "220c495c-95f9-411d-aa86-6b96c2778765",
                            Content = "Pretty neat!",
                            StartDate = new DateTime(2021, 5, 13, 9, 35, 0, 0, DateTimeKind.Unspecified),
                            TaskId = 2
                        },
                        new
                        {
                            CommentsId = 3,
                            AuthorId = "72546802-9b55-4a9c-9a4e-50bac18a0028",
                            Content = "Cumque qui odit consequatur provident molestiae qui voluptas.Vitae autem et consequatur ipsum.Quis ipsum exercitationem natus velit.Ut qui eum sint magnam doloremque. Voluptatibus enim non rerum facilis numquam ea error numquam.Quas et non eligendi a reprehenderit libero et assumenda.",
                            StartDate = new DateTime(2021, 5, 18, 14, 2, 0, 0, DateTimeKind.Unspecified),
                            TaskId = 1
                        });
                });

            modelBuilder.Entity("PlannerApi.Models.Projects.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssigneeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstimatedTime")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReporterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("SprintId")
                        .HasColumnType("int");

                    b.Property<int>("TaskPriorityId")
                        .HasColumnType("int");

                    b.Property<int>("TaskStatusId")
                        .HasColumnType("int");

                    b.Property<int>("TaskTypeId")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("ReporterId");

                    b.HasIndex("SprintId");

                    b.HasIndex("TaskPriorityId");

                    b.HasIndex("TaskStatusId");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            TaskId = 1,
                            AssigneeId = "220c495c-95f9-411d-aa86-6b96c2778765",
                            Description = "Task 1 description",
                            EstimatedTime = 10,
                            Name = "Task 1",
                            ReporterId = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                            SprintId = 1,
                            TaskPriorityId = 1,
                            TaskStatusId = 1,
                            TaskTypeId = 2
                        },
                        new
                        {
                            TaskId = 2,
                            AssigneeId = "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                            Description = "Task 2 description",
                            EstimatedTime = 16,
                            Name = "Task 2",
                            ReporterId = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                            SprintId = 2,
                            TaskPriorityId = 2,
                            TaskStatusId = 3,
                            TaskTypeId = 2
                        });
                });

            modelBuilder.Entity("PlannerApi.Models.Projects.TaskEntities.TaskPriority", b =>
                {
                    b.Property<int>("TaskPriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskPriorityId");

                    b.ToTable("TaskPriorities");

                    b.HasData(
                        new
                        {
                            TaskPriorityId = 1,
                            Name = "Low"
                        },
                        new
                        {
                            TaskPriorityId = 2,
                            Name = "Normal"
                        },
                        new
                        {
                            TaskPriorityId = 3,
                            Name = "High"
                        },
                        new
                        {
                            TaskPriorityId = 4,
                            Name = "Urgent"
                        },
                        new
                        {
                            TaskPriorityId = 5,
                            Name = "IMMEDIATE"
                        });
                });

            modelBuilder.Entity("PlannerApi.Models.Projects.TaskEntities.TaskStatus", b =>
                {
                    b.Property<int>("TaskStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskStatusId");

                    b.ToTable("TaskStatuses");

                    b.HasData(
                        new
                        {
                            TaskStatusId = 1,
                            TaskName = "New"
                        },
                        new
                        {
                            TaskStatusId = 2,
                            TaskName = "In progress"
                        },
                        new
                        {
                            TaskStatusId = 3,
                            TaskName = "Pending"
                        },
                        new
                        {
                            TaskStatusId = 4,
                            TaskName = "Testing"
                        },
                        new
                        {
                            TaskStatusId = 5,
                            TaskName = "Reply"
                        });
                });

            modelBuilder.Entity("PlannerApi.Models.Projects.TaskEntities.TaskType", b =>
                {
                    b.Property<int>("TaskTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskTypeId");

                    b.ToTable("TaskTypes");

                    b.HasData(
                        new
                        {
                            TaskTypeId = 1,
                            Name = "Task"
                        },
                        new
                        {
                            TaskTypeId = 2,
                            Name = "Error"
                        },
                        new
                        {
                            TaskTypeId = 3,
                            Name = "Proposal"
                        });
                });

            modelBuilder.Entity("PlannerApi.Models.Sprint", b =>
                {
                    b.Property<int>("SprintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SprintId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Sprints");

                    b.HasData(
                        new
                        {
                            SprintId = 1,
                            EndDate = new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sprint 1",
                            ProjectId = 1,
                            StartDate = new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SprintId = 2,
                            EndDate = new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sprint 2",
                            ProjectId = 1,
                            StartDate = new DateTime(2021, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SprintId = 3,
                            EndDate = new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sprint 3",
                            ProjectId = 2,
                            StartDate = new DateTime(2021, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SprintId = 4,
                            EndDate = new DateTime(2021, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sprint 4",
                            ProjectId = 2,
                            StartDate = new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SprintId = 5,
                            EndDate = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sprint 5",
                            ProjectId = 3,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PlannerApi.Models.Authentication.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "220c495c-95f9-411d-aa86-6b96c2778765",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "385ab67e-b229-475b-b110-cf22336fa7df",
                            Email = "Programmer1@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "PROGRAMMER1@GMAIL.COM",
                            NormalizedUserName = "PROGRAMMER1",
                            PasswordHash = "AQAAAAEAACcQAAAAEB8qNp+eOtMx8JJXoZofJRmtbZRzM+VAs4RRxM9jeCDlt3JFNCZUOHPztHsOQsFC2Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "UVK6CZ72YKWZSNU3TOGGRWOPDCTB3YYS",
                            TwoFactorEnabled = false,
                            UserName = "Programmer1",
                            FirstName = "Programmer1",
                            LastName = "Test",
                            Login = "Programmer1"
                        },
                        new
                        {
                            Id = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bbb82cb3-52aa-4343-aa6a-fe6905691128",
                            Email = "Mannager1@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MANNAGER1@GMAIL.COM",
                            NormalizedUserName = "MANNAGER1",
                            PasswordHash = "AQAAAAEAACcQAAAAEG7KrHWyF6XjbIf9Lo4U2t/gGw55YYSUCuWE3HiKLlEZ1sER+4J8ILQu6XMvEMb+SQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "A6RBR4GFIXSS22R7VNE2DROTJVBZJAP7",
                            TwoFactorEnabled = false,
                            UserName = "Mannager1",
                            FirstName = "Mannager1",
                            LastName = "TestMannager1",
                            Login = "Mannager1"
                        },
                        new
                        {
                            Id = "72546802-9b55-4a9c-9a4e-50bac18a0028",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ad608c87-5358-44a0-adbb-73fd943e967e",
                            Email = "Mannager2@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MANNAGER2@GMAIL.COM",
                            NormalizedUserName = "MANNAGER2",
                            PasswordHash = "AQAAAAEAACcQAAAAENQEpU1VkSDlK8cljaXgMLq+u7Ij51goayAWqOCG4l0r8so2kXS5R319JOlzyEwZGQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "F32OM56TU5PENGU2UTFFNLD3CYB23KY5",
                            TwoFactorEnabled = false,
                            UserName = "Mannager2",
                            FirstName = "Mannager2",
                            LastName = "TestMannager2",
                            Login = "Mannager2"
                        },
                        new
                        {
                            Id = "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5394588e-ac19-49c7-8561-d2c2ecdff835",
                            Email = "Tester1@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TESTER1@GMAIL.COM",
                            NormalizedUserName = "TESTER1",
                            PasswordHash = "AQAAAAEAACcQAAAAENCwxi/ZRTSt1d/QDilsEjojuoP8a+xlASCUUfFmKdLw+CE/5pWmXaMkubsBCpNUYg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "VHO7IDMB3IEVT5G4B75CR55SDVG6DWCE",
                            TwoFactorEnabled = false,
                            UserName = "Tester1",
                            FirstName = "Tester1",
                            LastName = "TestTester1",
                            Login = "Tester1"
                        },
                        new
                        {
                            Id = "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "61006890-1a43-42e8-9d07-ac32a67f7690",
                            Email = "Programmer2@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "PROGRAMMER2@GMAIL.COM",
                            NormalizedUserName = "PROGRAMMER2",
                            PasswordHash = "AQAAAAEAACcQAAAAEDR2zGwptCW0FbPNOrTN/vpprMfJkPfVt2qSMVbTxYKmYUbzKB2TmKjhOp/jLTo6bA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "KLHMYUGUJW7FOETIP7WLOKSUONMWV4WO",
                            TwoFactorEnabled = false,
                            UserName = "Programmer2",
                            FirstName = "Programmer2",
                            LastName = "Test2",
                            Login = "Programmer2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlannerApi.Models.ProjectUser", b =>
                {
                    b.HasOne("PlannerApi.Models.Project", "Project")
                        .WithMany("ProjectsUsers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlannerApi.Models.Authentication.User", "User")
                        .WithMany("ProjectsUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlannerApi.Models.Projects.Comments", b =>
                {
                    b.HasOne("PlannerApi.Models.Authentication.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("PlannerApi.Models.Projects.Task", "Task")
                        .WithMany("CommentsList")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlannerApi.Models.Projects.Task", b =>
                {
                    b.HasOne("PlannerApi.Models.Authentication.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("PlannerApi.Models.Authentication.User", "Reporter")
                        .WithMany()
                        .HasForeignKey("ReporterId");

                    b.HasOne("PlannerApi.Models.Sprint", "Sprint")
                        .WithMany("Tasks")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PlannerApi.Models.Projects.TaskEntities.TaskPriority", "TaskPriority")
                        .WithMany()
                        .HasForeignKey("TaskPriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlannerApi.Models.Projects.TaskEntities.TaskStatus", "TaskStatus")
                        .WithMany()
                        .HasForeignKey("TaskStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlannerApi.Models.Projects.TaskEntities.TaskType", "TaskType")
                        .WithMany()
                        .HasForeignKey("TaskTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlannerApi.Models.Sprint", b =>
                {
                    b.HasOne("PlannerApi.Models.Project", "Project")
                        .WithMany("Sprints")
                        .HasForeignKey("ProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
