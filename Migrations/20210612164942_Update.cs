using Microsoft.EntityFrameworkCore.Migrations;

namespace PlannerApi.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Sprints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 1,
                column: "ProjectId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 2,
                column: "ProjectId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 3,
                column: "ProjectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 4,
                column: "ProjectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 5,
                column: "ProjectId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_ProjectId",
                table: "Sprints",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Projects_ProjectId",
                table: "Sprints",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Projects_ProjectId",
                table: "Sprints");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_ProjectId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Sprints");
        }
    }
}
