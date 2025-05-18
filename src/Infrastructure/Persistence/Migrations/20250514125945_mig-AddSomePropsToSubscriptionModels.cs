using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migAddSomePropsToSubscriptionModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                schema: "Shared",
                table: "PanelTutorial",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<string>(
                name: "PageUrl",
                schema: "Job",
                table: "JobRankingHistory",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                schema: "Job",
                table: "JobRankingHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveAds",
                schema: "Job",
                table: "JobInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 14, 16, 29, 43, 708, DateTimeKind.Local).AddTicks(9126),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 15, 50, 12, 658, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.AddColumn<bool>(
                name: "JobIsActiveAds",
                schema: "Shared",
                table: "ActionHistories",
                type: "bit",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                schema: "Shared",
                table: "PanelTutorial");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                schema: "Job",
                table: "JobRankingHistory");

            migrationBuilder.DropColumn(
                name: "IsActiveAds",
                schema: "Job",
                table: "JobInfo");

            migrationBuilder.DropColumn(
                name: "JobIsActiveAds",
                schema: "Shared",
                table: "ActionHistories");

            migrationBuilder.AlterColumn<string>(
                name: "PageUrl",
                schema: "Job",
                table: "JobRankingHistory",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 15, 50, 12, 658, DateTimeKind.Local).AddTicks(2175),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 14, 16, 29, 43, 708, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "31145a3d-1f3f-4b45-acfa-e513d030f6cc", "AQAAAAIAAYagAAAAEDRkJayCgdAV+0Pi8RfOjYJy0JUImEJSui2I7okMQevVWJ6eE9kugmIh8OQXf5pViQ==", new DateTime(2025, 5, 11, 15, 50, 12, 675, DateTimeKind.Local).AddTicks(8021), "b47ec19c-f53f-403e-be12-8130e794ddc3" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "86d90176-4b85-406e-9142-a1c0e65cd6ea", "AQAAAAIAAYagAAAAEG6q1C6am2CdFgZCyRYtQl5JdHKhdsbwCqqqHk2tvHF9SFwo2Japk8V39VHbE2tMiQ==", new DateTime(2025, 5, 11, 15, 50, 12, 722, DateTimeKind.Local).AddTicks(6158), "d3ab1ca1-5604-41aa-985a-b27c8d64e061" });
        }
    }
}
