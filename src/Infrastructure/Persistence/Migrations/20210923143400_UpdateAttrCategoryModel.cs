using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateAttrCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUserAccess",
                schema: "dbo",
                table: "PromotionCode");

            migrationBuilder.AddColumn<bool>(
                name: "IsUseLimit",
                schema: "dbo",
                table: "PromotionCode",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUseLimit",
                schema: "dbo",
                table: "PromotionCode");

            migrationBuilder.AddColumn<bool>(
                name: "IsUserAccess",
                schema: "dbo",
                table: "PromotionCode",
                type: "bit",
                nullable: true);
        }
    }
}
