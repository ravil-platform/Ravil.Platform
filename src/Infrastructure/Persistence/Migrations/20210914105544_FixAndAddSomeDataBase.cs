using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class FixAndAddSomeDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banner_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.AddColumn<string>(
                name: "UserIp",
                schema: "dbo",
                table: "UserLikedGallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Rating",
                schema: "dbo",
                table: "UserJobAction",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActionDate",
                schema: "dbo",
                table: "UserJobAction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserIp",
                schema: "dbo",
                table: "UserBookMark",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActionDate",
                schema: "dbo",
                table: "UserBlogAction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "UserBannerClick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmationPatternCode",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordPatternCode",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Banner_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Banner",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banner_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "UserIp",
                schema: "dbo",
                table: "UserLikedGallery");

            migrationBuilder.DropColumn(
                name: "ActionDate",
                schema: "dbo",
                table: "UserJobAction");

            migrationBuilder.DropColumn(
                name: "UserIp",
                schema: "dbo",
                table: "UserBookMark");

            migrationBuilder.DropColumn(
                name: "ActionDate",
                schema: "dbo",
                table: "UserBlogAction");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "UserBannerClick");

            migrationBuilder.DropColumn(
                name: "ConfirmationPatternCode",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "ResetPasswordPatternCode",
                schema: "dbo",
                table: "Config");

            migrationBuilder.AlterColumn<byte>(
                name: "Rating",
                schema: "dbo",
                table: "UserJobAction",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Banner_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Banner",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
