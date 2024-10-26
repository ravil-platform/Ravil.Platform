using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class migAddMetaCanonicalUrlPropToBaseMetaDataEntityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "State",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "City",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "State");

            migrationBuilder.DropColumn(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "City");

            migrationBuilder.DropColumn(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "Blog");
        }
    }
}
