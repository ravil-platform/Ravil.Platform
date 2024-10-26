using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ravil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateversion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "City",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 12, 33, 2, 221, DateTimeKind.Local).AddTicks(8066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 12, 8, 14, 607, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "827f3431-2eb3-4e5e-bd63-d18e2a297d7b", "AQAAAAIAAYagAAAAEDc60dRslFzlhZ2ueVC90SU0/ZIncIHMDXgp4FSCPAsDC9jiNPtBeRig0C7YSxxn6Q==", new DateTime(2024, 10, 21, 12, 33, 2, 237, DateTimeKind.Local).AddTicks(617), "4731f28c-5d3f-4119-8543-26d0540bbed2" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "7e716553-ed70-4389-92cf-fbd9f8e4fa95", "AQAAAAIAAYagAAAAEP5ffII3f/T/1qgEouPtxhufqkzavjJDooUwQF7r/66UB/+Wfv/9jGgAbNTFZWDb6Q==", new DateTime(2024, 10, 21, 12, 33, 2, 295, DateTimeKind.Local).AddTicks(1224), "73841f3c-2a73-4f19-9fc1-3f4f2cda779f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "City",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 12, 8, 14, 607, DateTimeKind.Local).AddTicks(8335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 12, 33, 2, 221, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "b8ebd01b-fd9f-4232-8316-2bcc059a2540", "AQAAAAIAAYagAAAAEPZIRyRv9m8ANQxHTSVFSLQDIIieynhWAUUMIyQ5IHqaRD5tN9cA3NIjPMycSjdDEA==", new DateTime(2024, 10, 21, 12, 8, 14, 622, DateTimeKind.Local).AddTicks(4281), "2f470429-0a2f-49e7-bf14-a91cda40a3e0" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "6f9afc11-b085-4ed6-a2c6-6f3cb4793f8d", "AQAAAAIAAYagAAAAEHj0qvrj7mumjtCrBikcZfAE7gUIXHT2WrweC9a9eUzIfgaTdsvxhikh0fM39BXIpA==", new DateTime(2024, 10, 21, 12, 8, 14, 668, DateTimeKind.Local).AddTicks(9721), "88aedbe6-1355-4e5a-9c78-2bfa755faf6c" });
        }
    }
}
