using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class migAddSeoPatternPropsToConfiModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetaTitlePattern",
                schema: "dbo",
                table: "Config",
                newName: "JobsPersonalBrandMetaTitlePattern");

            migrationBuilder.RenameColumn(
                name: "MetaDescriptionPattern",
                schema: "dbo",
                table: "Config",
                newName: "CategoriesPersonalBrandMetaDescriptionPattern");

            migrationBuilder.AddColumn<string>(
                name: "CategoriesBrandNameMetaDescriptionPattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoriesMetaTitlePattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobsBrandNameMetaDescriptionPattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobsBrandNameMetaTitlePattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobsPersonalBrandMetaDescriptionPattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RedirectSeoPages",
                schema: "dbo",
                table: "Config",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriesBrandNameMetaDescriptionPattern",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "CategoriesMetaTitlePattern",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "JobsBrandNameMetaDescriptionPattern",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "JobsBrandNameMetaTitlePattern",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "JobsPersonalBrandMetaDescriptionPattern",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "RedirectSeoPages",
                schema: "dbo",
                table: "Config");

            migrationBuilder.RenameColumn(
                name: "JobsPersonalBrandMetaTitlePattern",
                schema: "dbo",
                table: "Config",
                newName: "MetaTitlePattern");

            migrationBuilder.RenameColumn(
                name: "CategoriesPersonalBrandMetaDescriptionPattern",
                schema: "dbo",
                table: "Config",
                newName: "MetaDescriptionPattern");
        }
    }
}
