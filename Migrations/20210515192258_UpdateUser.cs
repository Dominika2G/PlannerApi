using Microsoft.EntityFrameworkCore.Migrations;

namespace PlannerApi.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "220c495c-95f9-411d-aa86-6b96c2778765",
                column: "Login",
                value: "Programmer1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                column: "Login",
                value: "Mannager1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72546802-9b55-4a9c-9a4e-50bac18a0028",
                column: "Login",
                value: "Mannager2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                column: "Login",
                value: "Tester1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3",
                column: "Login",
                value: "Programmer2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "220c495c-95f9-411d-aa86-6b96c2778765",
                column: "Login",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                column: "Login",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72546802-9b55-4a9c-9a4e-50bac18a0028",
                column: "Login",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                column: "Login",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3",
                column: "Login",
                value: null);
        }
    }
}
