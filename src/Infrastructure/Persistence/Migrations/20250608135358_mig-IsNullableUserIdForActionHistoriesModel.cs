using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migIsNullableUserIdForActionHistoriesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 8, 17, 23, 57, 387, DateTimeKind.Local).AddTicks(4816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 20, 12, 32, 56, 803, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Shared",
                table: "ActionHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f7b826b5-479e-444d-a74e-4a55779fccd8", "AQAAAAIAAYagAAAAEI0r9WUV1lDL3Rua3iLTI9npxMYQojQeeTE5ru8l9FwLJdVzPnGVJ5+0dJgZysFb5A==", new DateTime(2025, 6, 8, 17, 23, 57, 451, DateTimeKind.Local).AddTicks(4710), "0c58f96f-b96a-43ce-82f6-ffce285cd357" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "84c5b4b3-02b2-4d1f-b697-4da3f552df28", "AQAAAAIAAYagAAAAEJF+dUjlblUTa3KAkMKEbZx2UK2LegCbxlAYfr0oJmXSwbxO7gU/DzGA1iwoHmjCaQ==", new DateTime(2025, 6, 8, 17, 23, 57, 502, DateTimeKind.Local).AddTicks(6240), "81473662-f475-4cb0-92e8-94fc473db56a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 20, 12, 32, 56, 803, DateTimeKind.Local).AddTicks(6455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 8, 17, 23, 57, 387, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Shared",
                table: "ActionHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "9dbbc6a1-bd68-44b3-94c4-52cc1d01351a", "AQAAAAIAAYagAAAAEHdIpo7kMZ1Vw5eTVAQShxDmS9WUvRIn+Td7RzsRb9i9SsHthsnsiRX7B6aKTFdjTA==", new DateTime(2025, 5, 20, 12, 32, 56, 820, DateTimeKind.Local).AddTicks(1223), "284211cb-3e5c-4ee5-b58a-4fc781e29209" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "574728b5-6c5a-4ea9-9995-6c92d905379c", "AQAAAAIAAYagAAAAEDkI6bDYuLgj6NgQFx/ltnkH2wVqyiHrJVgF4lO8ZOfnXyOn2uQ7dfTuABqrI7mzQQ==", new DateTime(2025, 5, 20, 12, 32, 56, 954, DateTimeKind.Local).AddTicks(7908), "c9cbbea8-9db4-4d97-880f-44543716d3bd" });
        }
    }
}
