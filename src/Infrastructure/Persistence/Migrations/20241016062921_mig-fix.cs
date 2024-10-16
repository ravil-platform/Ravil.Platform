using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migfix : Migration
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
                defaultValue: new DateTime(2024, 10, 16, 9, 59, 19, 858, DateTimeKind.Local).AddTicks(889),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 15, 9, 47, 20, 180, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                schema: "Users",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "27d67e17-a7e1-493e-9b9f-70d1a099ac89", "AQAAAAIAAYagAAAAEH3w0E5gBuk5H6xPaEobHM5T1DhHr1NeJYI9W1mt5kUSlmTLBCKoYxNLxJ7IQxIB4g==", new DateTime(2024, 10, 16, 9, 59, 19, 872, DateTimeKind.Local).AddTicks(5506), "2e868398-a248-4c35-86de-00010c63f526" });

            migrationBuilder.UpdateData(
                schema: "Users",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "81e62d2d-b117-43b7-995a-dde81d899219", "AQAAAAIAAYagAAAAEDDo35bUOj0uMQ6urWJcmRAGsYTar4oi6g+OR8qteZ+4i6cbs/A4cxzj9Vf6kV7H5Q==", new DateTime(2024, 10, 16, 9, 59, 19, 926, DateTimeKind.Local).AddTicks(982), "cb0e7634-7186-4d01-a3b3-400b15b207ba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 10, 16, 9, 59, 19, 858, DateTimeKind.Local).AddTicks(889));

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
    }
}
