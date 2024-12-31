using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Location",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 12, 51, 40, 987, DateTimeKind.Local).AddTicks(1561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 50, 24, 108, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "89cdec07-d822-4264-bace-82b79cafcaf8", "AQAAAAIAAYagAAAAEHHKIDqq1zc3ePmjEpjLw0LDSTgKlcN+ocH3+fH2NETzQNGoNKqbqc2mHIG7CqtOUA==", new DateTime(2024, 12, 31, 12, 51, 41, 15, DateTimeKind.Local).AddTicks(7580), "41db1702-3b2f-46d0-9b0b-90d01d556c08" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "17a9ae61-b1fc-4f9c-ae24-1e0b8dac8bd5", "AQAAAAIAAYagAAAAEHUaWHENPTcc75yXSOeJpDbcFmHR3k1L2uazllsT8rQ9HJoI/OdqY+8BzHQej1uelw==", new DateTime(2024, 12, 31, 12, 51, 41, 71, DateTimeKind.Local).AddTicks(7408), "f2691a59-f7bc-4f94-bec8-80b4071f1b13" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 11, 50, 24, 108, DateTimeKind.Local).AddTicks(8995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 12, 51, 40, 987, DateTimeKind.Local).AddTicks(1561));

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
        }
    }
}
