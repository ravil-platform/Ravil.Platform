using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ravil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixlocation : Migration
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
                defaultValue: new DateTime(2024, 11, 4, 8, 43, 37, 546, DateTimeKind.Local).AddTicks(955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 14, 53, 0, 697, DateTimeKind.Local).AddTicks(3793));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "7bd7db0b-f1b2-4e25-85e0-efb4dcaf5562", "AQAAAAIAAYagAAAAEC7BNX4z8ubjN6FH9hWrNMQiUYo/+efAuoRSr1BIrx8yl8ezQtd1LMDW13nubOvWkg==", new DateTime(2024, 11, 4, 8, 43, 37, 560, DateTimeKind.Local).AddTicks(3963), "534f37bf-4e5d-4f08-ba54-781bbdeaf70b" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "a94bfcf8-dc72-4c6e-be73-afb9e0f982e9", "AQAAAAIAAYagAAAAELxr0hDz2FgGZ/YPNvAuUbW5lLjLh89yI6LecXM+eY3SYrSDC7uSqTOpJQGzEnIcnw==", new DateTime(2024, 11, 4, 8, 43, 37, 609, DateTimeKind.Local).AddTicks(1038), "df516f80-82e7-4f06-bfec-27b5a06835e9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 14, 53, 0, 697, DateTimeKind.Local).AddTicks(3793),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 4, 8, 43, 37, 546, DateTimeKind.Local).AddTicks(955));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "b5db899d-0d21-4ce3-ad1e-ea3781d64997", "AQAAAAIAAYagAAAAEOOLC5lK15W5Tet+kxo+z8pzY9frQ8Bv0YeBjZzgVvjwTorYBeIuEDVt5+KZO0S6UA==", new DateTime(2024, 10, 21, 14, 53, 0, 708, DateTimeKind.Local).AddTicks(9411), "db99aca2-6b6b-49c8-92d6-60df56c776ea" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "5176fa03-ded8-4fc5-a711-475e43de1418", "AQAAAAIAAYagAAAAEIEXOzG11xyMNZ8FiEDOOdHDikCTOETYQnANW8DmS6bnGoiNc1vHMTjDc+W5AUWa3g==", new DateTime(2024, 10, 21, 14, 53, 0, 755, DateTimeKind.Local).AddTicks(867), "f6cddc64-0fa0-4ee4-84f4-b1acf983e410" });
        }
    }
}
