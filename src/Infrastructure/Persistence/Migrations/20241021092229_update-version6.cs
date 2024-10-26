using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ravil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateversion6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Location",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 12, 52, 28, 685, DateTimeKind.Local).AddTicks(2217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 12, 33, 2, 221, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "e6a5986e-2e25-43e1-a19d-98b3148841df", "AQAAAAIAAYagAAAAEACHetlijsfWgzALg/aiSnaSP0Mn4HuMpN3k67u6dKKi7AvnJ6u0NXydMdPrPhEnAA==", new DateTime(2024, 10, 21, 12, 52, 28, 697, DateTimeKind.Local).AddTicks(2082), "c956b3eb-4458-4738-8b00-ca4e2e190040" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "758d70e5-eb0b-481e-85e9-aeb35332de4d", "AQAAAAIAAYagAAAAEMLXRjmRZLYGfHxjbTNH+2SyacD07YD2uY63M2aq4CCkpplslBgbJlX6UyPNwM1k5Q==", new DateTime(2024, 10, 21, 12, 52, 28, 744, DateTimeKind.Local).AddTicks(9963), "2c49494a-ec22-435b-8d5f-e847c43083fa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 12, 33, 2, 221, DateTimeKind.Local).AddTicks(8066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 12, 52, 28, 685, DateTimeKind.Local).AddTicks(2217));

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
    }
}
