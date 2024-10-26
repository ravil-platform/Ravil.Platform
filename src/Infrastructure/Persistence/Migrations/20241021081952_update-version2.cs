using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ravil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateversion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [JobCategoriesView]
AS
SELECT        dbo.JobBranch.Id, dbo.JobBranch.JobId, dbo.Category.Id AS CategoryId, dbo.Category.Name AS Category, dbo.Job.Title, dbo.JobBranch.Title AS BranchTitle, dbo.CityBase.Name AS CityName
FROM            dbo.Job INNER JOIN
                         dbo.JobBranch ON dbo.Job.Id = dbo.JobBranch.JobId INNER JOIN
                         dbo.Address ON dbo.JobBranch.Id = dbo.Address.JobBranchId INNER JOIN
                         dbo.CityBase ON dbo.Address.CityId = dbo.CityBase.Id INNER JOIN
                         dbo.Category ON dbo.Job.Id = dbo.Category.Id
");

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 11, 49, 51, 369, DateTimeKind.Local).AddTicks(256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 11, 37, 46, 832, DateTimeKind.Local).AddTicks(363));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view JobCategoriesView;");

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 11, 37, 46, 832, DateTimeKind.Local).AddTicks(363),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 11, 49, 51, 369, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "d3d1b98b-017b-4ac9-838b-e975bd4ea51b", "AQAAAAIAAYagAAAAEMfeXEgV9hyujyXapGJRa4r5lXUgDEIaiGCsGA/NWKe12c9R3ISb9wxYqEPhW+aghQ==", new DateTime(2024, 10, 21, 11, 37, 46, 855, DateTimeKind.Local).AddTicks(3622), "00cc59a6-27bb-4ed7-91d3-50a0067eec2c" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "b10529e2-ea01-4955-9b7b-95bd5dfd108e", "AQAAAAIAAYagAAAAEFMtc4VUdzwsuLEmgO4NKyEAdAuyXplksrpxVPQhbVcMLEcG0XhJyCu1k0CeVlfWNw==", new DateTime(2024, 10, 21, 11, 37, 46, 937, DateTimeKind.Local).AddTicks(1899), "9e655b5a-e2df-4c4f-8ecf-efd6e3843a80" });
        }
    }
}
