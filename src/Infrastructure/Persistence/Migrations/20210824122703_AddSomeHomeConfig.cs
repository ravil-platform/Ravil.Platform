using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class AddSomeHomeConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomeDescription",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeSummery",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeDescription",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "HomeSummery",
                schema: "dbo",
                table: "Config");
        }
    }
}
