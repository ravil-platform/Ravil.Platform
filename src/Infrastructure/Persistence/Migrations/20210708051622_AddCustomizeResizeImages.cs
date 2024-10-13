using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddCustomizeResizeImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsResizePicture",
                schema: "dbo",
                table: "JobBranch",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsResizePicture",
                schema: "dbo",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsResizePicture",
                schema: "dbo",
                table: "City",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsResizePicture",
                schema: "dbo",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsResizePicture",
                schema: "dbo",
                table: "Blog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "dbo",
                table: "AnswerComment",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerCommentTitle",
                schema: "dbo",
                table: "AnswerComment",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                schema: "dbo",
                table: "AnswerComment",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsResizePicture",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "IsResizePicture",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsResizePicture",
                schema: "dbo",
                table: "City");

            migrationBuilder.DropColumn(
                name: "IsResizePicture",
                schema: "dbo",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsResizePicture",
                schema: "dbo",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "ReviewDate",
                schema: "dbo",
                table: "AnswerComment");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "dbo",
                table: "AnswerComment",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerCommentTitle",
                schema: "dbo",
                table: "AnswerComment",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
