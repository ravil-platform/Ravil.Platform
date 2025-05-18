using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migAddSomeChangesToPanelModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RenewalDate",
                schema: "Subscription",
                table: "UserSubscription",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                schema: "Wallet",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "Wallet",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "Subscription",
                table: "Subscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RenewalDate",
                schema: "Payment",
                table: "Payment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                schema: "Subscription",
                table: "Feature",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 15, 50, 12, 658, DateTimeKind.Local).AddTicks(2175),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 6, 16, 43, 31, 419, DateTimeKind.Local).AddTicks(8381));

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

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GiftCharge", "Price", "Type" },
                values: new object[] { 150000, 2900000, 1 });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discount", "DiscountAmount", "GiftCharge", "Price", "Type" },
                values: new object[] { (short)20, 830000.0, 250000, 4150000, 1 });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Discount", "DiscountAmount", "GiftCharge", "Price", "Type" },
                values: new object[] { (short)34, 2924000.0, 400000, 8600000, 1 });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GiftCharge", "Price", "Type" },
                values: new object[] { 250000, 4500000, 2 });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Discount", "DiscountAmount", "GiftCharge", "Price", "Type" },
                values: new object[] { (short)20, 1500000.0, 400000, 7500000, 2 });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Discount", "DiscountAmount", "GiftCharge", "Price", "Type" },
                values: new object[] { (short)34, 5304000.0, 900000, 15600000, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RenewalDate",
                schema: "Subscription",
                table: "UserSubscription");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "Wallet",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Number",
                schema: "Wallet",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Subscription",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "RenewalDate",
                schema: "Payment",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Icon",
                schema: "Subscription",
                table: "Feature");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 6, 16, 43, 31, 419, DateTimeKind.Local).AddTicks(8381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 15, 50, 12, 658, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "7a1221eb-07a6-420c-916c-2f794922e923", "AQAAAAIAAYagAAAAEMGrLGztCIL2mnrEPgqfm9mgRyIXfuzDf23ytcHe240Vfod+2pPhXTGV5Fez8AwHpA==", new DateTime(2025, 5, 6, 16, 43, 31, 438, DateTimeKind.Local).AddTicks(5206), "cdbff965-4c05-454a-b649-efbf67bf9483" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "09714f75-eff5-4d22-af0e-ff7dd8df1d5c", "AQAAAAIAAYagAAAAECrxgLCSamTmKl7AnFPM4l24Uv/dCQjMhlhnIFWGUb9spVSWkxaUVQ1lmc+MISRUGQ==", new DateTime(2025, 5, 6, 16, 43, 31, 485, DateTimeKind.Local).AddTicks(1813), "781b5d99-ec1b-47e6-bf7b-062a94f2b527" });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GiftCharge", "Price" },
                values: new object[] { 250000, 50000000 });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discount", "DiscountAmount", "GiftCharge", "Price" },
                values: new object[] { null, null, 500000, 100000000 });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Discount", "DiscountAmount", "GiftCharge", "Price" },
                values: new object[] { null, null, 1000000, 200000000 });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GiftCharge", "Price" },
                values: new object[] { 2500000, 500000000 });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Discount", "DiscountAmount", "GiftCharge", "Price" },
                values: new object[] { null, null, 5000000, 1000000000 });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Discount", "DiscountAmount", "GiftCharge", "Price" },
                values: new object[] { null, null, 10000000, 2000000000 });
        }
    }
}
