using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateContactUs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 14, 23, 39, 45, 608, DateTimeKind.Local).AddTicks(2974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 14, 20, 58, 316, DateTimeKind.Local).AddTicks(579));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 14, 20, 58, 316, DateTimeKind.Local).AddTicks(579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 14, 23, 39, 45, 608, DateTimeKind.Local).AddTicks(2974));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "5bf05544-a158-4cfd-a461-61b9e0b65bb1", "AQAAAAIAAYagAAAAEAdSWAFcCefHB45KX3uCk5jj/XDhpu2x9R97wpKWYgRsqctUu/blgZDP/dRnM32Dmg==", new DateTime(2024, 12, 31, 14, 20, 58, 336, DateTimeKind.Local).AddTicks(9888), "65a5d7a5-6e66-4050-b5ed-35067966eace" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "047ea722-3438-4c34-8d01-13a231955811", "AQAAAAIAAYagAAAAEDjQPtExCIotMDoMrwrxPWYbYrIG8+r+Cpv0+xJtTPopkvgVhuh/A1YEjbTwtmxmHA==", new DateTime(2024, 12, 31, 14, 20, 58, 405, DateTimeKind.Local).AddTicks(6682), "fd9392c3-64fd-4424-8a11-9684a0cee208" });
        }
    }
}
