using Microsoft.EntityFrameworkCore.Migrations;

namespace PlannerApi.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "222667d9-4543-498e-948a-5fc1c2dc2d62", "2420f8b1-58d7-49a7-8e44-7228b415b93a", "Mannager", "MANNAGER" },
                    { "471cd850-b05f-46ef-9c3b-5785ba3fadcd", "85cadb0c-05e9-4f65-8786-e33e35403468", "Programmer", "PROGRAMMER" },
                    { "b83721c8-b13c-4f4e-89a9-7797c4ed0c85", "92265458-1b6a-4a35-99bd-39feda4d1d7a", "Tester", "TESTER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Login" },
                values: new object[,]
                {
                    { "220c495c-95f9-411d-aa86-6b96c2778765", 0, "385ab67e-b229-475b-b110-cf22336fa7df", "User", "Programmer1@gmail.com", false, false, null, "PROGRAMMER1@GMAIL.COM", "PROGRAMMER1", "AQAAAAEAACcQAAAAEB8qNp+eOtMx8JJXoZofJRmtbZRzM+VAs4RRxM9jeCDlt3JFNCZUOHPztHsOQsFC2Q==", null, false, "UVK6CZ72YKWZSNU3TOGGRWOPDCTB3YYS", false, "Programmer1", "Programmer1", "Test", null },
                    { "547fb67e-7bac-4e68-ae07-7d7a2309b9d9", 0, "bbb82cb3-52aa-4343-aa6a-fe6905691128", "User", "Mannager1@gmail.com", false, false, null, "MANNAGER1@GMAIL.COM", "MANNAGER1", "AQAAAAEAACcQAAAAEG7KrHWyF6XjbIf9Lo4U2t/gGw55YYSUCuWE3HiKLlEZ1sER+4J8ILQu6XMvEMb+SQ==", null, false, "A6RBR4GFIXSS22R7VNE2DROTJVBZJAP7", false, "Mannager1", "Mannager1", "TestMannager1", null },
                    { "72546802-9b55-4a9c-9a4e-50bac18a0028", 0, "ad608c87-5358-44a0-adbb-73fd943e967e", "User", "Mannager2@gmail.com", false, false, null, "MANNAGER2@GMAIL.COM", "MANNAGER2", "AQAAAAEAACcQAAAAENQEpU1VkSDlK8cljaXgMLq+u7Ij51goayAWqOCG4l0r8so2kXS5R319JOlzyEwZGQ==", null, false, "F32OM56TU5PENGU2UTFFNLD3CYB23KY5", false, "Mannager2", "Mannager2", "TestMannager2", null },
                    { "877a0a41-23b3-4511-89f5-13d1cd5b750a", 0, "5394588e-ac19-49c7-8561-d2c2ecdff835", "User", "Tester1@gmail.com", false, false, null, "TESTER1@GMAIL.COM", "TESTER1", "AQAAAAEAACcQAAAAENCwxi/ZRTSt1d/QDilsEjojuoP8a+xlASCUUfFmKdLw+CE/5pWmXaMkubsBCpNUYg==", null, false, "VHO7IDMB3IEVT5G4B75CR55SDVG6DWCE", false, "Tester1", "Tester1", "TestTester1", null },
                    { "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3", 0, "61006890-1a43-42e8-9d07-ac32a67f7690", "User", "Programmer2@gmail.com", false, false, null, "PROGRAMMER2@GMAIL.COM", "PROGRAMMER2", "AQAAAAEAACcQAAAAEDR2zGwptCW0FbPNOrTN/vpprMfJkPfVt2qSMVbTxYKmYUbzKB2TmKjhOp/jLTo6bA==", null, false, "KLHMYUGUJW7FOETIP7WLOKSUONMWV4WO", false, "Programmer2", "Programmer2", "Test2", null }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "220c495c-95f9-411d-aa86-6b96c2778765", "471cd850-b05f-46ef-9c3b-5785ba3fadcd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "547fb67e-7bac-4e68-ae07-7d7a2309b9d9", "222667d9-4543-498e-948a-5fc1c2dc2d62" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "72546802-9b55-4a9c-9a4e-50bac18a0028", "222667d9-4543-498e-948a-5fc1c2dc2d62" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "877a0a41-23b3-4511-89f5-13d1cd5b750a", "b83721c8-b13c-4f4e-89a9-7797c4ed0c85" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3", "471cd850-b05f-46ef-9c3b-5785ba3fadcd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "222667d9-4543-498e-948a-5fc1c2dc2d62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "471cd850-b05f-46ef-9c3b-5785ba3fadcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b83721c8-b13c-4f4e-89a9-7797c4ed0c85");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "220c495c-95f9-411d-aa86-6b96c2778765");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "547fb67e-7bac-4e68-ae07-7d7a2309b9d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72546802-9b55-4a9c-9a4e-50bac18a0028");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "877a0a41-23b3-4511-89f5-13d1cd5b750a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
