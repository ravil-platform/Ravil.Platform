using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateBaseId",
                schema: "dbo",
                table: "CityBase",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 11, 17, 14, 997, DateTimeKind.Local).AddTicks(6722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 9, 57, 140, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "7a57f0a8-e188-4e64-a1f6-3d175a869c70", "AQAAAAIAAYagAAAAEOpx/nUrL7/TEiYwctxU11UUFSm+Lo9k0owYFRslehuudnl5yPVsxBNUIbjlWPNAGw==", new DateTime(2024, 12, 31, 11, 17, 15, 11, DateTimeKind.Local).AddTicks(6610), "e5e55544-2f05-46b2-9a6f-c384d02ee176" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f99c042e-17a8-45dd-8fde-225be721a67e", "AQAAAAIAAYagAAAAEBmWoucW1hKTsT3OKvZ6KzmPKGDkyjH6dMDSIJaC3CNfA8pwfo2KEL50LpXDQBU2TQ==", new DateTime(2024, 12, 31, 11, 17, 15, 61, DateTimeKind.Local).AddTicks(2271), "e076e366-d2a8-490f-802c-7166a739fb65" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateBaseId",
                schema: "dbo",
                table: "CityBase");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 11, 9, 57, 140, DateTimeKind.Local).AddTicks(3094),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 17, 14, 997, DateTimeKind.Local).AddTicks(6722));

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
    }
}
