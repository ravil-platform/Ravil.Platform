using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addCategoryTag : Migration
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
                defaultValue: new DateTime(2025, 2, 16, 10, 31, 59, 501, DateTimeKind.Local).AddTicks(9277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 15, 18, 24, 47, 714, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.CreateTable(
                name: "CategoryTag",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTag_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "dbo",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "a24a3f4e-f24e-462c-b476-c7119e22adaa", "AQAAAAIAAYagAAAAEFuktqcjl0EWrqxcIN+2pcRnK6Tt/U1WWZ4vPNLoCcghEg8lncaZgKWBZbSu9nV3YA==", new DateTime(2025, 2, 16, 10, 31, 59, 517, DateTimeKind.Local).AddTicks(982), "69d438ac-6701-4f05-b5f8-164ec70a459c" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f43a650c-bd3e-4ab8-80b3-7ebf4b264b56", "AQAAAAIAAYagAAAAEOwNtH/pGwYUgRn8smPYFH4OlBOYpiqiaa/JW0DEZarZO9qSTZkQWG/41mWrPWmd4Q==", new DateTime(2025, 2, 16, 10, 31, 59, 559, DateTimeKind.Local).AddTicks(4350), "56afd2af-7672-47db-96fa-a9bc08e78d23" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTag_CategoryId",
                schema: "dbo",
                table: "CategoryTag",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTag_TagId",
                schema: "dbo",
                table: "CategoryTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTag",
                schema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 15, 18, 24, 47, 714, DateTimeKind.Local).AddTicks(1005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 16, 10, 31, 59, 501, DateTimeKind.Local).AddTicks(9277));

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
    }
}
