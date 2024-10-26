using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class RemoveBranchBrandIdNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobBranch_Brand_BrandId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropIndex(
                name: "IX_JobBranch_BrandId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "BrandId",
                schema: "dbo",
                table: "JobBranch");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                schema: "dbo",
                table: "JobBranch",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobBranch_BrandId",
                schema: "dbo",
                table: "JobBranch",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranch_Brand_BrandId",
                schema: "dbo",
                table: "JobBranch",
                column: "BrandId",
                principalSchema: "dbo",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
