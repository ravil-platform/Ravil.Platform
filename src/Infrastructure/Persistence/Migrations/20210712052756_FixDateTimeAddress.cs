using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class FixDateTimeAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address");
        }
    }
}
