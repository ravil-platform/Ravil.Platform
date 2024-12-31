using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "dbo",
                table: "JobBranch",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RejectedReason",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 11, 30, 34, 149, DateTimeKind.Local).AddTicks(4024),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 17, 14, 997, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f30c0f15-f368-48c1-81c1-e5b51b45b726", "AQAAAAIAAYagAAAAECeMA5va4koJafog1VAqWfO39/S8S4AkIhm0T41sy00b4OvcNolCCHZH9DbIslnj1g==", new DateTime(2024, 12, 31, 11, 30, 34, 185, DateTimeKind.Local).AddTicks(7750), "a9b5d2f2-bb8f-493b-b2b4-ae1a36ca5a6d" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "8e5c0647-3633-4312-bf55-bfa11a78ad63", "AQAAAAIAAYagAAAAEF8Z6UB0OYrj4cL22GLYj4e/pIImhFj1eYhqJBrZe+2QLZ8GIINfjqe/zPC9tEsLOQ==", new DateTime(2024, 12, 31, 11, 30, 34, 255, DateTimeKind.Local).AddTicks(3384), "7c5181ee-775a-45a4-b98d-89bbe84c1583" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "dbo",
                table: "JobBranch",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RejectedReason",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 11, 17, 14, 997, DateTimeKind.Local).AddTicks(6722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 11, 30, 34, 149, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "7a57f0a8-e188-4e64-a1f6-3d175a869c70", "AQAAAAIAAYagAAAAEOpx/nUrL7/TEiYwctxU11UUFSm+Lo9k0owYFRslehuudnl5yPVsxBNUIbjlWPNAGw==", new DateTime(2024, 12, 31, 11, 17, 15, 11, DateTimeKind.Local).AddTicks(6610), "e5e55544-2f05-46b2-9a6f-c384d02ee176" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f99c042e-17a8-45dd-8fde-225be721a67e", "AQAAAAIAAYagAAAAEBmWoucW1hKTsT3OKvZ6KzmPKGDkyjH6dMDSIJaC3CNfA8pwfo2KEL50LpXDQBU2TQ==", new DateTime(2024, 12, 31, 11, 17, 15, 61, DateTimeKind.Local).AddTicks(2271), "e076e366-d2a8-490f-802c-7166a739fb65" });
        }
    }
}
