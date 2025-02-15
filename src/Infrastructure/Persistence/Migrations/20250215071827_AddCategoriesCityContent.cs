using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriesCityContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 15, 10, 48, 24, 305, DateTimeKind.Local).AddTicks(8335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 14, 23, 43, 46, 143, DateTimeKind.Local).AddTicks(1574));

            migrationBuilder.CreateTable(
                name: "CategoriesCityContent",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesCityContent", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "e5b609eb-7523-4e54-b1fb-98bf9983ac50", "AQAAAAIAAYagAAAAEOzma+fvii53uCpjxdRjenXn6z6EC8b775y97tJVRxg+fa6LS8eiZ/dkU2HfDEuWrQ==", new DateTime(2025, 2, 15, 10, 48, 24, 350, DateTimeKind.Local).AddTicks(7178), "c6a04bd4-f932-4cbc-83b4-a0750b88d357" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "75ac8370-3bce-4fb8-b648-50e1d265cd8d", "AQAAAAIAAYagAAAAEDJsaLGayD+PJoy58GFbwK+dei0lUupWl8aHnJ9XzpWIvKZHCahREZxTgo7bYCJRVQ==", new DateTime(2025, 2, 15, 10, 48, 24, 435, DateTimeKind.Local).AddTicks(8569), "6810f7e9-0e27-47b1-b5e7-d56fd650326d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesCityContent",
                schema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 14, 23, 43, 46, 143, DateTimeKind.Local).AddTicks(1574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 15, 10, 48, 24, 305, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "3c8b891d-7334-4964-8199-da4a24bf037c", "AQAAAAIAAYagAAAAEAQ5Ps89fN/SSvUiAhWSBsvkd3+Hz/QKcpuoMoE8+chedkfQy8lpTokelbkHHisfbQ==", new DateTime(2025, 1, 14, 23, 43, 46, 180, DateTimeKind.Local).AddTicks(1692), "59340304-8409-4e71-b6d5-cd5b0307c64e" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "bfea00a5-1c35-4ad3-9704-9db17fbc9e22", "AQAAAAIAAYagAAAAEOI7TzR1cz7J07xGc2yZWmWSN9bmyrmEPmo5t4YbRLcJei5CUO++X6GRhiuzut0r9g==", new DateTime(2025, 1, 14, 23, 43, 46, 271, DateTimeKind.Local).AddTicks(3861), "1acd56b5-9247-47ed-9f00-7abb93ca60b5" });
        }
    }
}
