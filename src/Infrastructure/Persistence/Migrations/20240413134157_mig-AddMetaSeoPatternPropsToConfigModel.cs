using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class migAddMetaSeoPatternPropsToConfigModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaDescriptionPattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitlePattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaDescriptionPattern",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "MetaTitlePattern",
                schema: "dbo",
                table: "Config");
        }
    }
}
