using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCategoryFieldToKeyword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCategory",
                schema: "Job",
                table: "Keyword",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 20, 12, 32, 56, 803, DateTimeKind.Local).AddTicks(6455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 14, 16, 29, 43, 708, DateTimeKind.Local).AddTicks(9126));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCategory",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 14, 16, 29, 43, 708, DateTimeKind.Local).AddTicks(9126),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 20, 12, 32, 56, 803, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "81a35f55-fc59-4214-a6a5-715d26d5eba4", "AQAAAAIAAYagAAAAEEY51mwlczbHiKwliaklasLjktiBx1OmYZkR7+dpoFXAP1VPpGQ+gz1B8aTY1AoFMg==", new DateTime(2025, 5, 14, 16, 29, 43, 728, DateTimeKind.Local).AddTicks(4847), "fb9a3e3c-0cdf-4390-81ac-359c5a2cd28a" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "d54e590d-f5af-48ba-b6be-38a6df6c6a19", "AQAAAAIAAYagAAAAENBlYV2znJKFl8pE4YDYRzH1eKVYFMNLkuQELtLYMYK9Y46YMPO/n+KAooGxTwz4/A==", new DateTime(2025, 5, 14, 16, 29, 43, 778, DateTimeKind.Local).AddTicks(84), "e9963471-3828-4416-b072-7e25987221ee" });
        }
    }
}
