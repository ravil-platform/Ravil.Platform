using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migNullableSomePropsForSubscriptionClickModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Position",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "KeywordId",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 9, 11, 18, 25, 636, DateTimeKind.Local).AddTicks(4130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 8, 17, 23, 57, 387, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "68482ce1-b538-4305-8e85-50e7a8328d84", "AQAAAAIAAYagAAAAECXx5mCO49O2sWRp/nrrUF11RtMMNQj5Ys3JtPFvZCX1/aUu39hy1imHdDjxQ28+vQ==", new DateTime(2025, 6, 9, 11, 18, 25, 710, DateTimeKind.Local).AddTicks(9525), "576a4885-d9b4-40e1-96dc-2327f477a169" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f743637f-1385-48e1-9c83-11ff6e189bf8", "AQAAAAIAAYagAAAAEKIQCCXoa1N5Pquj2579IU6NyKaAnnDi51ZcEEuzvuWYkMpHmo1S8zR+AFJ8rf250w==", new DateTime(2025, 6, 9, 11, 18, 25, 764, DateTimeKind.Local).AddTicks(2909), "2ec55dcf-9287-486b-8af0-5cfbe20b21f8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Position",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "KeywordId",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 8, 17, 23, 57, 387, DateTimeKind.Local).AddTicks(4816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 9, 11, 18, 25, 636, DateTimeKind.Local).AddTicks(4130));

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
    }
}
