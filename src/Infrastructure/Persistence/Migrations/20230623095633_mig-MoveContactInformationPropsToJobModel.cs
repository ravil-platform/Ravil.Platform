using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class migMoveContactInformationPropsToJobModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumberInfos",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "ShowFirstPhoneMobileInSite",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "ShowPhoneTelInSite",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "SocialMediaInfos",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "AdditionalPhoneNumber",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "SocialName",
                schema: "dbo",
                table: "Job");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberInfos",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowFirstPhoneMobileInSite",
                schema: "dbo",
                table: "Job",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowPhoneTelInSite",
                schema: "dbo",
                table: "Job",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaInfos",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumberInfos",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "ShowFirstPhoneMobileInSite",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "ShowPhoneTelInSite",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "SocialMediaInfos",
                schema: "dbo",
                table: "Job");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberInfos",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaInfos",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalPhoneNumber",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialName",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
