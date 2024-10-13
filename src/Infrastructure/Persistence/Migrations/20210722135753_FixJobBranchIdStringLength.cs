using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixJobBranchIdStringLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobBranchAttr_JobBranch_JobBranchId",
                schema: "dbo",
                table: "JobBranchAttr");

            migrationBuilder.DropIndex(
                name: "IX_JobBranchAttr_JobBranchId",
                schema: "dbo",
                table: "JobBranchAttr");

            migrationBuilder.DropColumn(
                name: "JobBranchId",
                schema: "dbo",
                table: "JobBranchAttr");

            migrationBuilder.AlterColumn<string>(
                name: "SmallPicture",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LargePicture",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchAttr_BranchId",
                schema: "dbo",
                table: "JobBranchAttr",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranchAttr_JobBranch_BranchId",
                schema: "dbo",
                table: "JobBranchAttr",
                column: "BranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobBranchAttr_JobBranch_BranchId",
                schema: "dbo",
                table: "JobBranchAttr");

            migrationBuilder.DropIndex(
                name: "IX_JobBranchAttr_BranchId",
                schema: "dbo",
                table: "JobBranchAttr");

            migrationBuilder.AddColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "JobBranchAttr",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmallPicture",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LargePicture",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchAttr_JobBranchId",
                schema: "dbo",
                table: "JobBranchAttr",
                column: "JobBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranchAttr_JobBranch_JobBranchId",
                schema: "dbo",
                table: "JobBranchAttr",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id");
        }
    }
}
