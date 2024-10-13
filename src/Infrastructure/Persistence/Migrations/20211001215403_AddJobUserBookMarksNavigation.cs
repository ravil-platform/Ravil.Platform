using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddJobUserBookMarksNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "UserBookMark",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBookMark_JobBranchId",
                schema: "dbo",
                table: "UserBookMark",
                column: "JobBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookMark_JobBranch_JobBranchId",
                schema: "dbo",
                table: "UserBookMark",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookMark_JobBranch_JobBranchId",
                schema: "dbo",
                table: "UserBookMark");

            migrationBuilder.DropIndex(
                name: "IX_UserBookMark_JobBranchId",
                schema: "dbo",
                table: "UserBookMark");

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "UserBookMark",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
