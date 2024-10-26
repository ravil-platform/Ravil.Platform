using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class AddJobBrandIdNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobBrandId",
                schema: "dbo",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobBrandId",
                schema: "dbo",
                table: "Job",
                column: "JobBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Brand_JobBrandId",
                schema: "dbo",
                table: "Job",
                column: "JobBrandId",
                principalSchema: "dbo",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Brand_JobBrandId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_JobBrandId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "JobBrandId",
                schema: "dbo",
                table: "Job");
        }
    }
}
