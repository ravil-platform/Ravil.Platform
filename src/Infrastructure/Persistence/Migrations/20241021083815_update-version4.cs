using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ravil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateversion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeadingTitle",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 12, 8, 14, 607, DateTimeKind.Local).AddTicks(8335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 12, 7, 16, 155, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "b8ebd01b-fd9f-4232-8316-2bcc059a2540", "AQAAAAIAAYagAAAAEPZIRyRv9m8ANQxHTSVFSLQDIIieynhWAUUMIyQ5IHqaRD5tN9cA3NIjPMycSjdDEA==", new DateTime(2024, 10, 21, 12, 8, 14, 622, DateTimeKind.Local).AddTicks(4281), "2f470429-0a2f-49e7-bf14-a91cda40a3e0" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "6f9afc11-b085-4ed6-a2c6-6f3cb4793f8d", "AQAAAAIAAYagAAAAEHj0qvrj7mumjtCrBikcZfAE7gUIXHT2WrweC9a9eUzIfgaTdsvxhikh0fM39BXIpA==", new DateTime(2024, 10, 21, 12, 8, 14, 668, DateTimeKind.Local).AddTicks(9721), "88aedbe6-1355-4e5a-9c78-2bfa755faf6c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeadingTitle",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 12, 7, 16, 155, DateTimeKind.Local).AddTicks(4622),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 12, 8, 14, 607, DateTimeKind.Local).AddTicks(8335));

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
    }
}
