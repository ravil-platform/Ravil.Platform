using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class AddSupportBoxConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupportBoxDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupportBoxTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupportBoxDesc",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "SupportBoxTitle",
                schema: "dbo",
                table: "Config");
        }
    }
}
