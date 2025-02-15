using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addRelatedCategorySeo : Migration
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
                defaultValue: new DateTime(2025, 2, 15, 18, 24, 47, 714, DateTimeKind.Local).AddTicks(1005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 15, 10, 48, 24, 305, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.CreateTable(
                name: "RelatedCategorySeo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<bool>(type: "bit", nullable: false),
                    CurrentCityId = table.Column<int>(type: "int", nullable: false),
                    CurrentCityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayedCityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedCategorySeo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "e9c8cce7-e0b6-4e45-976a-9d1bef45fcb3", "AQAAAAIAAYagAAAAEDmunCIjgNNMX1rkiJ90CTXlX9PQmQS0WKlrSWdZJZqkZqqYNs6j++NgVsNIo8Cfrg==", new DateTime(2025, 2, 15, 18, 24, 47, 726, DateTimeKind.Local).AddTicks(9857), "30b30c59-fba3-4e70-861c-ff380368fa00" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f7292aca-36af-4347-9e3b-fef2a3a17a88", "AQAAAAIAAYagAAAAEOA3/PnwbBMfLo+G7vYvQ12jDT2NETKYZZIl3PKd1KkG/YnCcolNtIGeAjQc19+jVg==", new DateTime(2025, 2, 15, 18, 24, 47, 770, DateTimeKind.Local).AddTicks(8110), "64b7c8a7-b1ea-4a22-9d1a-1aa2e17c0ba9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatedCategorySeo",
                schema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 15, 10, 48, 24, 305, DateTimeKind.Local).AddTicks(8335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 15, 18, 24, 47, 714, DateTimeKind.Local).AddTicks(1005));

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
    }
}
