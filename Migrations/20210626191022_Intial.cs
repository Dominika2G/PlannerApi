using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlannerApi.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskPriorities",
                columns: table => new
                {
                    TaskPriorityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPriorities", x => x.TaskPriorityId);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    TaskStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => x.TaskStatusId);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    TaskTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.TaskTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsUsers", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectsUsers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    SprintId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.SprintId);
                    table.ForeignKey(
                        name: "FK_Sprints_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EstimatedTime = table.Column<int>(nullable: true),
                    TaskPriorityId = table.Column<int>(nullable: false),
                    TaskStatusId = table.Column<int>(nullable: false),
                    TaskTypeId = table.Column<int>(nullable: false),
                    SprintId = table.Column<int>(nullable: true),
                    ReporterId = table.Column<string>(nullable: true),
                    AssigneeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Sprints_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprints",
                        principalColumn: "SprintId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskPriorities_TaskPriorityId",
                        column: x => x.TaskPriorityId,
                        principalTable: "TaskPriorities",
                        principalColumn: "TaskPriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskStatuses_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalTable: "TaskStatuses",
                        principalColumn: "TaskStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "TaskTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentsId);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "222667d9-4543-498e-948a-5fc1c2dc2d62", "2420f8b1-58d7-49a7-8e44-7228b415b93a", "Manager", "MANAGER" },
                    { "471cd850-b05f-46ef-9c3b-5785ba3fadcd", "85cadb0c-05e9-4f65-8786-e33e35403468", "Programmer", "PROGRAMMER" },
                    { "b83721c8-b13c-4f4e-89a9-7797c4ed0c85", "92265458-1b6a-4a35-99bd-39feda4d1d7a", "Tester", "TESTER" },
                    { "b585f129-1abe-44f9-90a9-1e5d354973cb", "0f602014-30b7-4e62-b18d-c16ad06ddaae", "Unauthorize", "UNAUTHORIZE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Login" },
                values: new object[,]
                {
                    { "220c495c-95f9-411d-aa86-6b96c2778765", 0, "385ab67e-b229-475b-b110-cf22336fa7df", "User", "Programmer1@gmail.com", false, false, null, "PROGRAMMER1@GMAIL.COM", "PROGRAMMER1", "AQAAAAEAACcQAAAAEB8qNp+eOtMx8JJXoZofJRmtbZRzM+VAs4RRxM9jeCDlt3JFNCZUOHPztHsOQsFC2Q==", null, false, "UVK6CZ72YKWZSNU3TOGGRWOPDCTB3YYS", false, "Programmer1", "Programmer1", "Test", "Programmer1" },
                    { "547fb67e-7bac-4e68-ae07-7d7a2309b9d9", 0, "bbb82cb3-52aa-4343-aa6a-fe6905691128", "User", "Mannager1@gmail.com", false, false, null, "MANNAGER1@GMAIL.COM", "MANNAGER1", "AQAAAAEAACcQAAAAEG7KrHWyF6XjbIf9Lo4U2t/gGw55YYSUCuWE3HiKLlEZ1sER+4J8ILQu6XMvEMb+SQ==", null, false, "A6RBR4GFIXSS22R7VNE2DROTJVBZJAP7", false, "Mannager1", "Mannager1", "TestMannager1", "Mannager1" },
                    { "72546802-9b55-4a9c-9a4e-50bac18a0028", 0, "ad608c87-5358-44a0-adbb-73fd943e967e", "User", "Mannager2@gmail.com", false, false, null, "MANNAGER2@GMAIL.COM", "MANNAGER2", "AQAAAAEAACcQAAAAENQEpU1VkSDlK8cljaXgMLq+u7Ij51goayAWqOCG4l0r8so2kXS5R319JOlzyEwZGQ==", null, false, "F32OM56TU5PENGU2UTFFNLD3CYB23KY5", false, "Mannager2", "Mannager2", "TestMannager2", "Mannager2" },
                    { "877a0a41-23b3-4511-89f5-13d1cd5b750a", 0, "5394588e-ac19-49c7-8561-d2c2ecdff835", "User", "Tester1@gmail.com", false, false, null, "TESTER1@GMAIL.COM", "TESTER1", "AQAAAAEAACcQAAAAENCwxi/ZRTSt1d/QDilsEjojuoP8a+xlASCUUfFmKdLw+CE/5pWmXaMkubsBCpNUYg==", null, false, "VHO7IDMB3IEVT5G4B75CR55SDVG6DWCE", false, "Tester1", "Tester1", "TestTester1", "Tester1" },
                    { "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3", 0, "61006890-1a43-42e8-9d07-ac32a67f7690", "User", "Programmer2@gmail.com", false, false, null, "PROGRAMMER2@GMAIL.COM", "PROGRAMMER2", "AQAAAAEAACcQAAAAEDR2zGwptCW0FbPNOrTN/vpprMfJkPfVt2qSMVbTxYKmYUbzKB2TmKjhOp/jLTo6bA==", null, false, "KLHMYUGUJW7FOETIP7WLOKSUONMWV4WO", false, "Programmer2", "Programmer2", "Test2", "Programmer2" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Polsl galaxy" },
                    { 3, "Steam 2.0" },
                    { 5, "Some random stuff" },
                    { 1, "Cryptowallet" },
                    { 2, "Darknet AI" }
                });

            migrationBuilder.InsertData(
                table: "TaskPriorities",
                columns: new[] { "TaskPriorityId", "Name" },
                values: new object[,]
                {
                    { 1, "Low" },
                    { 2, "Normal" },
                    { 3, "High" },
                    { 4, "Urgent" },
                    { 5, "IMMEDIATE" }
                });

            migrationBuilder.InsertData(
                table: "TaskStatuses",
                columns: new[] { "TaskStatusId", "TaskName" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "In progress" },
                    { 3, "Pending" },
                    { 4, "Testing" },
                    { 5, "Reply" }
                });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "TaskTypeId", "Name" },
                values: new object[,]
                {
                    { 2, "Error" },
                    { 1, "Task" },
                    { 3, "Proposal" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "220c495c-95f9-411d-aa86-6b96c2778765", "471cd850-b05f-46ef-9c3b-5785ba3fadcd" },
                    { "547fb67e-7bac-4e68-ae07-7d7a2309b9d9", "222667d9-4543-498e-948a-5fc1c2dc2d62" },
                    { "72546802-9b55-4a9c-9a4e-50bac18a0028", "222667d9-4543-498e-948a-5fc1c2dc2d62" },
                    { "877a0a41-23b3-4511-89f5-13d1cd5b750a", "b83721c8-b13c-4f4e-89a9-7797c4ed0c85" },
                    { "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3", "471cd850-b05f-46ef-9c3b-5785ba3fadcd" }
                });

            migrationBuilder.InsertData(
                table: "ProjectsUsers",
                columns: new[] { "UserId", "ProjectId" },
                values: new object[,]
                {
                    { "547fb67e-7bac-4e68-ae07-7d7a2309b9d9", 1 },
                    { "220c495c-95f9-411d-aa86-6b96c2778765", 1 },
                    { "877a0a41-23b3-4511-89f5-13d1cd5b750a", 1 },
                    { "72546802-9b55-4a9c-9a4e-50bac18a0028", 2 },
                    { "877a0a41-23b3-4511-89f5-13d1cd5b750a", 2 }
                });

            migrationBuilder.InsertData(
                table: "Sprints",
                columns: new[] { "SprintId", "EndDate", "Name", "ProjectId", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 1", 1, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 2", 1, new DateTime(2021, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 3", 2, new DateTime(2021, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 4", 2, new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 5", 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "AssigneeId", "Description", "EstimatedTime", "Name", "ReporterId", "SprintId", "TaskPriorityId", "TaskStatusId", "TaskTypeId" },
                values: new object[] { 1, "220c495c-95f9-411d-aa86-6b96c2778765", "Task 1 description", 10, "Task 1", "547fb67e-7bac-4e68-ae07-7d7a2309b9d9", 1, 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "AssigneeId", "Description", "EstimatedTime", "Name", "ReporterId", "SprintId", "TaskPriorityId", "TaskStatusId", "TaskTypeId" },
                values: new object[] { 2, "877a0a41-23b3-4511-89f5-13d1cd5b750a", "Task 2 description", 16, "Task 2", "547fb67e-7bac-4e68-ae07-7d7a2309b9d9", 2, 2, 3, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentsId", "AuthorId", "Content", "StartDate", "TaskId" },
                values: new object[] { 1, "547fb67e-7bac-4e68-ae07-7d7a2309b9d9", "Some random stuff goes here.", new DateTime(2021, 5, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentsId", "AuthorId", "Content", "StartDate", "TaskId" },
                values: new object[] { 3, "72546802-9b55-4a9c-9a4e-50bac18a0028", "Cumque qui odit consequatur provident molestiae qui voluptas.Vitae autem et consequatur ipsum.Quis ipsum exercitationem natus velit.Ut qui eum sint magnam doloremque. Voluptatibus enim non rerum facilis numquam ea error numquam.Quas et non eligendi a reprehenderit libero et assumenda.", new DateTime(2021, 5, 18, 14, 2, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentsId", "AuthorId", "Content", "StartDate", "TaskId" },
                values: new object[] { 2, "220c495c-95f9-411d-aa86-6b96c2778765", "Pretty neat!", new DateTime(2021, 5, 13, 9, 35, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskId",
                table: "Comments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsUsers_ProjectId",
                table: "ProjectsUsers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_ProjectId",
                table: "Sprints",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssigneeId",
                table: "Tasks",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ReporterId",
                table: "Tasks",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SprintId",
                table: "Tasks",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskPriorityId",
                table: "Tasks",
                column: "TaskPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskStatusId",
                table: "Tasks",
                column: "TaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ProjectsUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropTable(
                name: "TaskPriorities");

            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
