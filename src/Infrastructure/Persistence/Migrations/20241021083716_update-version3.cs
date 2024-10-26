using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ravil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateversion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ConfirmationDate",
                schema: "dbo",
                table: "JobBranch",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 12, 7, 16, 155, DateTimeKind.Local).AddTicks(4622),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 11, 49, 51, 369, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "a5eb29f4-57ae-42ea-8fbe-99faecbe66c2", "AQAAAAIAAYagAAAAEEqdpOzVOBjpLsrpcbblF4IHZUMnUFrtwBbwK6YfMbHnk6bi3sYlyMY5XYamEbJ7yw==", new DateTime(2024, 10, 21, 12, 7, 16, 167, DateTimeKind.Local).AddTicks(2265), "edf01399-d13b-443b-ba8c-3e3b18e2b6a3" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "46e5cc3a-b091-4dea-b3eb-4afb4ee7f7d1", "AQAAAAIAAYagAAAAEJqdyoziTuOT08bcO5OnoAp8a/6sD0ddeFkexRagZL1Ud2zwNg5Rv5lLjIK6lUax+A==", new DateTime(2024, 10, 21, 12, 7, 16, 215, DateTimeKind.Local).AddTicks(6532), "90c26580-332c-47ce-8fd5-033dc8f6c8f4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ConfirmationDate",
                schema: "dbo",
                table: "JobBranch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 11, 49, 51, 369, DateTimeKind.Local).AddTicks(256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 12, 7, 16, 155, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "72296863-ac5a-461b-b0c0-bedd8683ae46", "AQAAAAIAAYagAAAAELt1M6LqUCi851gPmnvcm3x7vIqNNHcGfEEO9xIA/iOQd3uyNYUe3pHF7YoT90OAbA==", new DateTime(2024, 10, 21, 11, 49, 51, 382, DateTimeKind.Local).AddTicks(3658), "0d54f0be-6d86-4d89-9739-68f3e652b33f" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "d09a4716-8de2-462a-8b08-2879d41debf8", "AQAAAAIAAYagAAAAEMOc8cyDDYhaL9G6OvFz7I9kGo8p8QZneYGXGa1DetpZ5rTbywLrP4XAYHWMRORLYg==", new DateTime(2024, 10, 21, 11, 49, 51, 429, DateTimeKind.Local).AddTicks(4155), "97678815-0d4d-433d-83d0-8400c35c1055" });
        }
    }
}
