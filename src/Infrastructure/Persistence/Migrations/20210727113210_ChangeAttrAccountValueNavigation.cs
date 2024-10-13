using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangeAttrAccountValueNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttrValue_AttrAccount_AttrAccountId",
                schema: "dbo",
                table: "AttrValue");

            migrationBuilder.DropIndex(
                name: "IX_AttrValue_AttrAccountId",
                schema: "dbo",
                table: "AttrValue");

            migrationBuilder.DropColumn(
                name: "AttrAccountId",
                schema: "dbo",
                table: "AttrValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttrAccountId",
                schema: "dbo",
                table: "AttrValue",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttrValue_AttrAccountId",
                schema: "dbo",
                table: "AttrValue",
                column: "AttrAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttrValue_AttrAccount_AttrAccountId",
                schema: "dbo",
                table: "AttrValue",
                column: "AttrAccountId",
                principalSchema: "dbo",
                principalTable: "AttrAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
