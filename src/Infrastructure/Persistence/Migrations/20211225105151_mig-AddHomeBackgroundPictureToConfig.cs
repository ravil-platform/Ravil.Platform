using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class migAddHomeBackgroundPictureToConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainSlider_JobBranch_JobBranchId",
                schema: "dbo",
                table: "MainSlider");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "MainSlider",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LinkPage",
                schema: "dbo",
                table: "MainSlider",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "MainSlider",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "HomeMainExtFileName",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeMainPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MainSlider_JobBranch_JobBranchId",
                schema: "dbo",
                table: "MainSlider",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainSlider_JobBranch_JobBranchId",
                schema: "dbo",
                table: "MainSlider");

            migrationBuilder.DropColumn(
                name: "HomeMainExtFileName",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "HomeMainPicture",
                schema: "dbo",
                table: "Config");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "MainSlider",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkPage",
                schema: "dbo",
                table: "MainSlider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "MainSlider",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MainSlider_JobBranch_JobBranchId",
                schema: "dbo",
                table: "MainSlider",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
