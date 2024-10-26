using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class migAddRedirectionUrlModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RedirectionUrl",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RedirectionType = table.Column<int>(type: "int", nullable: false),
                    LatestUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedirectionUrl", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RedirectionUrl",
                schema: "dbo");
        }
    }
}
