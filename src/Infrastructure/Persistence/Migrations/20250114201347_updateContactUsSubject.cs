using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateContactUsSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 14, 23, 43, 46, 143, DateTimeKind.Local).AddTicks(1574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 14, 23, 39, 45, 608, DateTimeKind.Local).AddTicks(2974));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 14, 23, 39, 45, 608, DateTimeKind.Local).AddTicks(2974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 14, 23, 43, 46, 143, DateTimeKind.Local).AddTicks(1574));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "875ead10-deef-4298-8686-51d047cf600d", "AQAAAAIAAYagAAAAEM7+GxKRnb+4nbVwS/jCuWlGkMKaZsT2so8Bxtyln+hx4kii+39fgzczuqQLYdLaJA==", new DateTime(2025, 1, 14, 23, 39, 45, 638, DateTimeKind.Local).AddTicks(538), "118b8c8c-fdcd-48bc-814d-8e0a7fd96f7c" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "12c73337-5095-45e9-b365-1104043ecddf", "AQAAAAIAAYagAAAAECMa5AUExSHS0aR0sKPszkBayC2FJMzL34wVbuA128rv8DjYI9bn9dslJTOhNhHKDg==", new DateTime(2025, 1, 14, 23, 39, 45, 726, DateTimeKind.Local).AddTicks(7306), "15ef083a-f991-4aec-ae62-660b6717ae61" });
        }
    }
}
