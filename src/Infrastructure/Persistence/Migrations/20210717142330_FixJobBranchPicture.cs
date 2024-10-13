using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixJobBranchPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationDate",
                schema: "dbo",
                table: "JobBranch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmedByAdmin",
                schema: "dbo",
                table: "JobBranch",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LargePicture",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallPicture",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationDate",
                schema: "dbo",
                table: "Job",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmedByAdmin",
                schema: "dbo",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMultipleCreate",
                schema: "dbo",
                table: "Config",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationDate",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "IsConfirmedByAdmin",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "LargePicture",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "SmallPicture",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "ConfirmationDate",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsConfirmedByAdmin",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsMultipleCreate",
                schema: "dbo",
                table: "Config");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
