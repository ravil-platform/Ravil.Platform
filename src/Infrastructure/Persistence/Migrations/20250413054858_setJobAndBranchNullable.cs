using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class setJobAndBranchNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 13, 9, 18, 57, 24, DateTimeKind.Local).AddTicks(2086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 16, 10, 31, 59, 501, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f0b8766e-17f9-471e-8b7d-769a3ce427d3", "AQAAAAIAAYagAAAAEKgGuSvO2BaE18x1gYIkn+dtabfpx9rSUv71MrUVDc84mZRA0swnK18hLTX66VS2xA==", new DateTime(2025, 4, 13, 9, 18, 57, 39, DateTimeKind.Local).AddTicks(3255), "67d69f8c-a83c-44aa-8b13-f902ffe4c6d8" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "8009d613-9419-4e84-af3a-765a8ab9815f", "AQAAAAIAAYagAAAAECFMY04BE8jUqkmJ7HO4Ia7fDtJk04F9gQYr8SZpp2grhXCFs5J/OzGESDzK5Sr8Zw==", new DateTime(2025, 4, 13, 9, 18, 57, 85, DateTimeKind.Local).AddTicks(9455), "db36bd9a-a30b-4bf2-b0b2-90ea10e46879" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 16, 10, 31, 59, 501, DateTimeKind.Local).AddTicks(9277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 13, 9, 18, 57, 24, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "a24a3f4e-f24e-462c-b476-c7119e22adaa", "AQAAAAIAAYagAAAAEFuktqcjl0EWrqxcIN+2pcRnK6Tt/U1WWZ4vPNLoCcghEg8lncaZgKWBZbSu9nV3YA==", new DateTime(2025, 2, 16, 10, 31, 59, 517, DateTimeKind.Local).AddTicks(982), "69d438ac-6701-4f05-b5f8-164ec70a459c" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f43a650c-bd3e-4ab8-80b3-7ebf4b264b56", "AQAAAAIAAYagAAAAEOwNtH/pGwYUgRn8smPYFH4OlBOYpiqiaa/JW0DEZarZO9qSTZkQWG/41mWrPWmd4Q==", new DateTime(2025, 2, 16, 10, 31, 59, 559, DateTimeKind.Local).AddTicks(4350), "56afd2af-7672-47db-96fa-a9bc08e78d23" });
        }
    }
}
