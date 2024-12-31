using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityBase_StateBase_StateId",
                schema: "dbo",
                table: "CityBase");

            migrationBuilder.DropIndex(
                name: "IX_CityBase_StateId",
                schema: "dbo",
                table: "CityBase");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 11, 50, 24, 108, DateTimeKind.Local).AddTicks(8995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 32, 15, 297, DateTimeKind.Local).AddTicks(7904));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "b294f3a6-1f8e-4793-87f6-3596c9f9c298", "AQAAAAIAAYagAAAAEGfowiDX4y5Pzt3gt7yRrcN6takUnIaN4r/iGOhMiLTdESveQdI2HJoWLPTHhPLQIQ==", new DateTime(2024, 12, 31, 11, 50, 24, 121, DateTimeKind.Local).AddTicks(7407), "9f583ec6-2f3a-4e91-8627-3f55b812bbb4" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "876488be-9438-47aa-8d36-b8bc9f0e3c91", "AQAAAAIAAYagAAAAEOrbx9DlgRoce5le7Mx3OjjDr2Uynxn4NHFcscw9MBxO5TT63ykopYXLvIR7XEOm0Q==", new DateTime(2024, 12, 31, 11, 50, 24, 169, DateTimeKind.Local).AddTicks(1946), "6cef9361-606b-4db4-a5db-6c47b3bf5ab3" });

            migrationBuilder.CreateIndex(
                name: "IX_CityBase_StateBaseId",
                schema: "dbo",
                table: "CityBase",
                column: "StateBaseId",
                unique: true,
                filter: "[StateBaseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CityBase_StateBase_StateBaseId",
                schema: "dbo",
                table: "CityBase",
                column: "StateBaseId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityBase_StateBase_StateBaseId",
                schema: "dbo",
                table: "CityBase");

            migrationBuilder.DropIndex(
                name: "IX_CityBase_StateBaseId",
                schema: "dbo",
                table: "CityBase");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 11, 32, 15, 297, DateTimeKind.Local).AddTicks(7904),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 50, 24, 108, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "b322ccc4-6bc4-49c4-9b84-a7c4ae6ade85", "AQAAAAIAAYagAAAAENarpiLniSjwzL88osHXj0cv+4vdXtS8aha2MiBRKi2oRbAAJLHr/5oF0M6+fHsxlg==", new DateTime(2024, 12, 31, 11, 32, 15, 311, DateTimeKind.Local).AddTicks(9890), "b2f68cd0-5a9e-48d6-8d5f-92bc81c236e2" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f5dce386-4497-475c-974d-3b0078a69d0f", "AQAAAAIAAYagAAAAEDOHCgsv69WAomJbMPZdXeY6zP1DV1r5tZ5wU98x0Gmya7Xuv7cRnjtAl07DoqBq1w==", new DateTime(2024, 12, 31, 11, 32, 15, 365, DateTimeKind.Local).AddTicks(1609), "74115b35-f39d-42f8-8357-db83d8ff3120" });

            migrationBuilder.CreateIndex(
                name: "IX_CityBase_StateId",
                schema: "dbo",
                table: "CityBase",
                column: "StateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CityBase_StateBase_StateId",
                schema: "dbo",
                table: "CityBase",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id");
        }
    }
}
