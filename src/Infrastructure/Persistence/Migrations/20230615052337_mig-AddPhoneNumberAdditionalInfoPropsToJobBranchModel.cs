using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class migAddPhoneNumberAdditionalInfoPropsToJobBranchModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowFirstPhoneMobileInSite",
                schema: "dbo",
                table: "JobBranch",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowPhoneTelInSite",
                schema: "dbo",
                table: "JobBranch",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowFirstPhoneMobileInSite",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "ShowPhoneTelInSite",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
