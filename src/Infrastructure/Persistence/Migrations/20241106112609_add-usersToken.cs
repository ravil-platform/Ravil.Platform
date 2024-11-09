using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ravil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addusersToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresse_ApplicationUser_UserId",
                schema: "dbo",
                table: "UserAddresse");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresse_CityBase_CityBaseId",
                schema: "dbo",
                table: "UserAddresse");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresse_StateBase_StateBaseId",
                schema: "dbo",
                table: "UserAddresse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddresse",
                schema: "dbo",
                table: "UserAddresse");

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

            migrationBuilder.RenameTable(
                name: "UserAddresse",
                schema: "dbo",
                newName: "UserAddresses",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresse_UserId",
                schema: "dbo",
                table: "UserAddresses",
                newName: "IX_UserAddresses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresse_StateBaseId",
                schema: "dbo",
                table: "UserAddresses",
                newName: "IX_UserAddresses_StateBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresse_CityBaseId",
                schema: "dbo",
                table: "UserAddresses",
                newName: "IX_UserAddresses_CityBaseId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 14, 56, 8, 155, DateTimeKind.Local).AddTicks(4403),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 4, 8, 43, 37, 546, DateTimeKind.Local).AddTicks(955));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddresses",
                schema: "dbo",
                table: "UserAddresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsersToken",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashJwtToken = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    HashRefreshToken = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    TokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshTokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Device = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToken", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "c7aa7263-6226-4dcb-b04a-55e33ec7ecb1", "AQAAAAIAAYagAAAAEP5XknxJOUK9iwJyX3QDWapNyEO9DOYGdshOejknxqVea1C/pFtJxv8p1DcHKXFzTA==", new DateTime(2024, 11, 6, 14, 56, 8, 167, DateTimeKind.Local).AddTicks(6846), "096196de-295d-4c17-9936-ef15c61df6ed" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "11267502-1e21-4d32-a39a-013b1558c684", "AQAAAAIAAYagAAAAEPBBpM/OZZ6Buhsqz1HeyN0XDfoSr66gGnT5pp6BeLcPYIsNkMXPVMPVaks3ltPAZw==", new DateTime(2024, 11, 6, 14, 56, 8, 215, DateTimeKind.Local).AddTicks(7274), "864c443f-1136-4c40-aa97-afe7ca4b3852" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_ApplicationUser_UserId",
                schema: "dbo",
                table: "UserAddresses",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_CityBase_CityBaseId",
                schema: "dbo",
                table: "UserAddresses",
                column: "CityBaseId",
                principalSchema: "dbo",
                principalTable: "CityBase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_StateBase_StateBaseId",
                schema: "dbo",
                table: "UserAddresses",
                column: "StateBaseId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_ApplicationUser_UserId",
                schema: "dbo",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_CityBase_CityBaseId",
                schema: "dbo",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_StateBase_StateBaseId",
                schema: "dbo",
                table: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UsersToken",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddresses",
                schema: "dbo",
                table: "UserAddresses");

            migrationBuilder.RenameTable(
                name: "UserAddresses",
                schema: "dbo",
                newName: "UserAddresse",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresses_UserId",
                schema: "dbo",
                table: "UserAddresse",
                newName: "IX_UserAddresse_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresses_StateBaseId",
                schema: "dbo",
                table: "UserAddresse",
                newName: "IX_UserAddresse_StateBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresses_CityBaseId",
                schema: "dbo",
                table: "UserAddresse",
                newName: "IX_UserAddresse_CityBaseId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Location",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 4, 8, 43, 37, 546, DateTimeKind.Local).AddTicks(955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 14, 56, 8, 155, DateTimeKind.Local).AddTicks(4403));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddresse",
                schema: "dbo",
                table: "UserAddresse",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "7bd7db0b-f1b2-4e25-85e0-efb4dcaf5562", "AQAAAAIAAYagAAAAEC7BNX4z8ubjN6FH9hWrNMQiUYo/+efAuoRSr1BIrx8yl8ezQtd1LMDW13nubOvWkg==", new DateTime(2024, 11, 4, 8, 43, 37, 560, DateTimeKind.Local).AddTicks(3963), "534f37bf-4e5d-4f08-ba54-781bbdeaf70b" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "a94bfcf8-dc72-4c6e-be73-afb9e0f982e9", "AQAAAAIAAYagAAAAELxr0hDz2FgGZ/YPNvAuUbW5lLjLh89yI6LecXM+eY3SYrSDC7uSqTOpJQGzEnIcnw==", new DateTime(2024, 11, 4, 8, 43, 37, 609, DateTimeKind.Local).AddTicks(1038), "df516f80-82e7-4f06-bfec-27b5a06835e9" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresse_ApplicationUser_UserId",
                schema: "dbo",
                table: "UserAddresse",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresse_CityBase_CityBaseId",
                schema: "dbo",
                table: "UserAddresse",
                column: "CityBaseId",
                principalSchema: "dbo",
                principalTable: "CityBase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresse_StateBase_StateBaseId",
                schema: "dbo",
                table: "UserAddresse",
                column: "StateBaseId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
