using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ravil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateversion7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Location_LocationId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_LocationId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                schema: "dbo",
                table: "Location",
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
                defaultValue: new DateTime(2024, 10, 21, 12, 54, 14, 339, DateTimeKind.Local).AddTicks(2931),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 12, 52, 28, 685, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.AlterColumn<string>(
                name: "LocationId",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                schema: "dbo",
                table: "Address",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Location_LocationId",
                schema: "dbo",
                table: "Address",
                column: "LocationId",
                principalSchema: "dbo",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Location_LocationId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_LocationId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                schema: "dbo",
                table: "Location",
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
                defaultValue: new DateTime(2024, 10, 21, 12, 52, 28, 685, DateTimeKind.Local).AddTicks(2217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 12, 54, 14, 339, DateTimeKind.Local).AddTicks(2931));

            migrationBuilder.AlterColumn<string>(
                name: "LocationId",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                schema: "dbo",
                table: "Address",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Location_LocationId",
                schema: "dbo",
                table: "Address",
                column: "LocationId",
                principalSchema: "dbo",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
