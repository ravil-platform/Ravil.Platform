using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "dbo",
                table: "Job",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "RejectedReason",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 11, 9, 57, 140, DateTimeKind.Local).AddTicks(3094),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 7, 28, 315, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "5bfdd26e-26f4-460c-835c-14324a84cd59", "AQAAAAIAAYagAAAAEKAO8NNO6vxPiaLxSldbPfK0I1s30j1IhtRlTDucka1lUOEs/9kTADizdKDLuCOU+A==", new DateTime(2024, 12, 31, 11, 9, 57, 158, DateTimeKind.Local).AddTicks(3564), "18a89333-c4b3-4fe1-8644-c3062cfd88e3" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "96228aa2-e24c-4c59-b797-d286762d2cc9", "AQAAAAIAAYagAAAAEO0mhcmUYzU1X2f/30+4CnmzwOwSIWkAiTC8rAhOV29NzMPasvh9nwn7n0ZqvuzI+Q==", new DateTime(2024, 12, 31, 11, 9, 57, 228, DateTimeKind.Local).AddTicks(2607), "c2b5182a-2194-49c0-941f-9cb81b390d39" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "dbo",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RejectedReason",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 11, 7, 28, 315, DateTimeKind.Local).AddTicks(285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 9, 57, 140, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "45e8e729-4b7f-40e4-aea8-d2a6fc35dfb0", "AQAAAAIAAYagAAAAEKS7aNSI4w5SDjztk3hmgTDp+vJr7WXbWbmziC5ZVQ/KlIo1aufgvqEb7O5f3L79lw==", new DateTime(2024, 12, 31, 11, 7, 28, 331, DateTimeKind.Local).AddTicks(1554), "bcb913c0-e79f-48e8-b33f-29e5c135cf50" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "b697c9c4-2d9b-48ea-9701-8406ff9c62f5", "AQAAAAIAAYagAAAAEK5WHsl7KVeFo8EsWUXMN3KE05MZGeY5873hhnc7YJAQjQ+b5tmI0QGlFyZ9bdZ4gg==", new DateTime(2024, 12, 31, 11, 7, 28, 400, DateTimeKind.Local).AddTicks(5954), "efda3014-ec01-46e9-98b0-e73e07cc9b0a" });
        }
    }
}
