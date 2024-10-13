using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class migAddNoIndexSeoPagesPropToConfigModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NoIndexSeoPages",
                schema: "dbo",
                table: "Config",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                schema: "dbo",
                table: "Category",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoIndexSeoPages",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "dbo",
                table: "Category");
        }
    }
}
