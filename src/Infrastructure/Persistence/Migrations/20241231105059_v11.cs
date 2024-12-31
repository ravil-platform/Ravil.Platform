using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 14, 20, 58, 316, DateTimeKind.Local).AddTicks(579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 13, 0, 22, 904, DateTimeKind.Local).AddTicks(2477));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 13, 0, 22, 904, DateTimeKind.Local).AddTicks(2477),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 14, 20, 58, 316, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "14d2b25d-a781-48f3-a26a-3a15c3ec6799", "AQAAAAIAAYagAAAAEAI2s3izdDjDGZI77rRLxW0JqoKmCMhjlGCp+iCULpBMSFidDXjZz0SOAHRbPOQk7g==", new DateTime(2024, 12, 31, 13, 0, 22, 917, DateTimeKind.Local).AddTicks(936), "69e5023d-88ff-4f6e-9203-2c31917c0840" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "df13c90a-a469-48fa-a8a9-09f8b730b38e", "AQAAAAIAAYagAAAAEGl4nui0DMWFLx1jwAuMAVpEyQCw7flC3w5dKC+gc+N9ZwXww0WQrpNni8BxO9nl6A==", new DateTime(2024, 12, 31, 13, 0, 22, 963, DateTimeKind.Local).AddTicks(5130), "6a42b573-17e7-4df2-9fcf-c6505db51e7f" });
        }
    }
}
