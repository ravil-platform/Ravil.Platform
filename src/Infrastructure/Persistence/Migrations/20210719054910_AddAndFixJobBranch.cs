using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddAndFixJobBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchContent",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminName",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchContent",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "AdminId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "AdminName",
                schema: "dbo",
                table: "Job");
        }
    }
}
