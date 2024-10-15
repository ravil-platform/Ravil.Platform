using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migSetIdForActionHistoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Addresses",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 15, 9, 47, 20, 180, DateTimeKind.Local).AddTicks(8281),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 14, 12, 19, 38, 44, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "ActionHistories",
                table: "ActionHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionHistories",
                schema: "ActionHistories",
                table: "ActionHistories",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "Users",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "ff49a00a-69e0-4a46-8c57-8ded34f3c2fd", "L0DcCkwhQ8SHMfeN16k4Zoz5LYQWfT3mypSt6r4M8oo=", new DateTime(2024, 10, 15, 9, 47, 20, 191, DateTimeKind.Local).AddTicks(8881), "d09e28f4-2068-495e-9234-99d9cb2a4513" });

            migrationBuilder.UpdateData(
                schema: "Users",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "3535af37-b6a1-4c6b-8d8d-ff98cb3b0200", "sabjcPE0ts3t+tJm3f6+uh8tpUhjfvO6NpJikNGh1kk=", new DateTime(2024, 10, 15, 9, 47, 20, 191, DateTimeKind.Local).AddTicks(8965), "319b8a4f-5442-4b68-aca5-ef4cd7a1b315" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionHistories",
                schema: "ActionHistories",
                table: "ActionHistories");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "ActionHistories",
                table: "ActionHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Addresses",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 14, 12, 19, 38, 44, DateTimeKind.Local).AddTicks(1010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 15, 9, 47, 20, 180, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                schema: "Users",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "661bc32a-f5cb-45c9-93fc-e564868be568", "AQAAAAIAAYagAAAAEGUxpwcDBbDTFLVxLB9jDZfq6z8squRBAChCc86kOHmCaTQcXqFFmbPuycl2vf+DKg==", new DateTime(2024, 10, 14, 12, 19, 38, 145, DateTimeKind.Local).AddTicks(2779), "6608e7df-9fae-4a11-9864-9a035e58f81d" });

            migrationBuilder.UpdateData(
                schema: "Users",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "318e1ef7-1937-43bb-8918-ffaafe804a30", "AQAAAAIAAYagAAAAEI69lhfI/cVBhuZWjvuTS+cBt/Eb8S9rGZOHUq8bbIi2OfgYTTbuquTLE1R30lFB2A==", new DateTime(2024, 10, 14, 12, 19, 38, 242, DateTimeKind.Local).AddTicks(4093), "9fc02fda-5294-451d-b52a-12738491ad08" });
        }
    }
}
