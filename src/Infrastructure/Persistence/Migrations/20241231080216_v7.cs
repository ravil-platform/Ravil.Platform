using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PageContent",
                schema: "dbo",
                table: "Category",
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
                defaultValue: new DateTime(2024, 12, 31, 11, 32, 15, 297, DateTimeKind.Local).AddTicks(7904),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 30, 34, 149, DateTimeKind.Local).AddTicks(4024));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PageContent",
                schema: "dbo",
                table: "Category",
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
                defaultValue: new DateTime(2024, 12, 31, 11, 30, 34, 149, DateTimeKind.Local).AddTicks(4024),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 32, 15, 297, DateTimeKind.Local).AddTicks(7904));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f30c0f15-f368-48c1-81c1-e5b51b45b726", "AQAAAAIAAYagAAAAECeMA5va4koJafog1VAqWfO39/S8S4AkIhm0T41sy00b4OvcNolCCHZH9DbIslnj1g==", new DateTime(2024, 12, 31, 11, 30, 34, 185, DateTimeKind.Local).AddTicks(7750), "a9b5d2f2-bb8f-493b-b2b4-ae1a36ca5a6d" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "8e5c0647-3633-4312-bf55-bfa11a78ad63", "AQAAAAIAAYagAAAAEF8Z6UB0OYrj4cL22GLYj4e/pIImhFj1eYhqJBrZe+2QLZ8GIINfjqe/zPC9tEsLOQ==", new DateTime(2024, 12, 31, 11, 30, 34, 255, DateTimeKind.Local).AddTicks(3384), "7c5181ee-775a-45a4-b98d-89bbe84c1583" });
        }
    }
}
