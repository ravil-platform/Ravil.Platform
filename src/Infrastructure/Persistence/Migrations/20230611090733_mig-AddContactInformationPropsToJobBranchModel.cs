using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class migAddContactInformationPropsToJobBranchModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberInfos",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaInfos",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumberInfos",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "SocialMediaInfos",
                schema: "dbo",
                table: "JobBranch");
        }
    }
}
