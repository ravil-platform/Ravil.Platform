using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                schema: "dbo",
                table: "Comment",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 13, 0, 22, 904, DateTimeKind.Local).AddTicks(2477),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 12, 51, 40, 987, DateTimeKind.Local).AddTicks(1561));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                schema: "dbo",
                table: "Comment",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 12, 51, 40, 987, DateTimeKind.Local).AddTicks(1561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 13, 0, 22, 904, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "89cdec07-d822-4264-bace-82b79cafcaf8", "AQAAAAIAAYagAAAAEHHKIDqq1zc3ePmjEpjLw0LDSTgKlcN+ocH3+fH2NETzQNGoNKqbqc2mHIG7CqtOUA==", new DateTime(2024, 12, 31, 12, 51, 41, 15, DateTimeKind.Local).AddTicks(7580), "41db1702-3b2f-46d0-9b0b-90d01d556c08" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "17a9ae61-b1fc-4f9c-ae24-1e0b8dac8bd5", "AQAAAAIAAYagAAAAEHUaWHENPTcc75yXSOeJpDbcFmHR3k1L2uazllsT8rQ9HJoI/OdqY+8BzHQej1uelw==", new DateTime(2024, 12, 31, 12, 51, 41, 71, DateTimeKind.Local).AddTicks(7408), "f2691a59-f7bc-4f94-bec8-80b4071f1b13" });
        }
    }
}
