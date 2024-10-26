using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ravil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateversion8 : Migration
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
                defaultValue: new DateTime(2024, 10, 21, 14, 53, 0, 697, DateTimeKind.Local).AddTicks(3793),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 12, 54, 14, 339, DateTimeKind.Local).AddTicks(2931));

            migrationBuilder.AlterColumn<string>(
                name: "ActionType",
                schema: "dbo",
                table: "ActionHistories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 12, 54, 14, 339, DateTimeKind.Local).AddTicks(2931),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 14, 53, 0, 697, DateTimeKind.Local).AddTicks(3793));

            migrationBuilder.AlterColumn<int>(
                name: "ActionType",
                schema: "dbo",
                table: "ActionHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "500fd4e0-fc9a-40ce-8c42-f0e9db7de518", "AQAAAAIAAYagAAAAEKNaU9kk7xfYujCDcy1Nq4A2B/cA8cXGf2U+4Q16gTo47kNEdk/pJ7TyX1Fs8eIt+g==", new DateTime(2024, 10, 21, 12, 54, 14, 351, DateTimeKind.Local).AddTicks(5284), "06c44174-29ac-4117-9ac7-4fbd013e2609" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f7b228f7-9605-47d6-b6bf-44a6a4dd56fb", "AQAAAAIAAYagAAAAEDW7gh9WNH0vEM4aiRkdtCllTxNtBtWTfvAy3+AZRqTEt+JpFDE+EJ2Ui6WdOeke1A==", new DateTime(2024, 10, 21, 12, 54, 14, 401, DateTimeKind.Local).AddTicks(7943), "58d0ee32-f74d-4ca7-b015-46e276ef216e" });
        }
    }
}
