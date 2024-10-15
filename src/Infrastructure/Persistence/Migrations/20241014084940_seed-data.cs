using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "Users",
                table: "ApplicationUser",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "Users",
                table: "ApplicationUser",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                schema: "Users",
                table: "ApplicationUser",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Users",
                table: "ApplicationUser",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Addresses",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 14, 12, 19, 38, 44, DateTimeKind.Local).AddTicks(1010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 13, 16, 56, 21, 822, DateTimeKind.Local).AddTicks(1013));

            migrationBuilder.CreateTable(
                name: "IdentityRole<Guid>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<Guid>", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Users",
                table: "ApplicationUser",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "BirthDate", "BlockedDate", "CityBaseId", "ConcurrencyStamp", "ConfirmationDate", "Email", "EmailConfirmed", "ExpireTimeSpanBlock", "Firstname", "Gender", "IsDeleted", "LastDeleteBicycleDate", "LastUpdateDateReason", "Lastname", "LockoutEnabled", "LockoutEnd", "LockoutReason", "NationalCode", "NormalizedEmail", "NormalizedUserName", "OneTimeUseCode", "OneTimeUseCodeEnd", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "RegisterDate", "SecurityStamp", "StateBaseId", "StateId", "TwoFactorEnabled", "UpdateDate", "UserIsBlocked", "UserName", "UserNameType" },
                values: new object[,]
                {
                    { "05446344-f9cc-4566-bd2c-36791b4e28ed", 0, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "661bc32a-f5cb-45c9-93fc-e564868be568", null, "admin@localhost.com", true, 0, "Admin", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "System", false, null, null, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", null, null, "AQAAAAIAAYagAAAAEGUxpwcDBbDTFLVxLB9jDZfq6z8squRBAChCc86kOHmCaTQcXqFFmbPuycl2vf+DKg==", null, null, false, new DateTime(2024, 10, 14, 12, 19, 38, 145, DateTimeKind.Local).AddTicks(2779), "6608e7df-9fae-4a11-9864-9a035e58f81d", null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@localhost.com", 0 },
                    { "2ec9f480-7288-4d0f-a1cd-53cc89968b45", 0, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "318e1ef7-1937-43bb-8918-ffaafe804a30", null, "user@localhost.com", true, 0, "System", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", false, null, null, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", null, null, "AQAAAAIAAYagAAAAEI69lhfI/cVBhuZWjvuTS+cBt/Eb8S9rGZOHUq8bbIi2OfgYTTbuquTLE1R30lFB2A==", null, null, false, new DateTime(2024, 10, 14, 12, 19, 38, 242, DateTimeKind.Local).AddTicks(4093), "9fc02fda-5294-451d-b52a-12738491ad08", null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user@localhost.com", 0 }
                });

            migrationBuilder.InsertData(
                table: "IdentityRole<Guid>",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("9845f909-799c-45fd-9158-58c1336ffddc"), null, "User", "USER" },
                    { new Guid("cb275765-1cac-4652-a03f-f8871dd575d1"), null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole<Guid>");

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed");

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "Users",
                table: "ApplicationUser",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "Users",
                table: "ApplicationUser",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                schema: "Users",
                table: "ApplicationUser",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Users",
                table: "ApplicationUser",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Addresses",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 13, 16, 56, 21, 822, DateTimeKind.Local).AddTicks(1013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 14, 12, 19, 38, 44, DateTimeKind.Local).AddTicks(1010));
        }
    }
}
