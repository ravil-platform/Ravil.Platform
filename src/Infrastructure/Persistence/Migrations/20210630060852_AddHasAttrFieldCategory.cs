using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddHasAttrFieldCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCategory_JobBranch_JobBranchId",
                schema: "dbo",
                table: "JobCategory");

            migrationBuilder.DropIndex(
                name: "IX_JobCategory_JobBranchId",
                schema: "dbo",
                table: "JobCategory");

            migrationBuilder.DropColumn(
                name: "JobBranchId",
                schema: "dbo",
                table: "JobCategory");

            migrationBuilder.AddColumn<bool>(
                name: "HasAttribute",
                schema: "dbo",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAttribute",
                schema: "dbo",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "JobCategory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobCategory_JobBranchId",
                schema: "dbo",
                table: "JobCategory",
                column: "JobBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCategory_JobBranch_JobBranchId",
                schema: "dbo",
                table: "JobCategory",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
