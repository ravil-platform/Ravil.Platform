using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class migRemoveTestPropForTestDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestDateTime",
                schema: "dbo",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TestDateTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }
    }
}
