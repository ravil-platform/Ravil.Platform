using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemoveAccountAttrsNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAttr_Attr_AttrId1",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountAttr_AttrValue_AttrValueId",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropIndex(
                name: "IX_AccountAttr_AttrId1",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropIndex(
                name: "IX_AccountAttr_AttrValueId",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropColumn(
                name: "AttrId1",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropColumn(
                name: "AttrValueId",
                schema: "dbo",
                table: "AccountAttr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttrId1",
                schema: "dbo",
                table: "AccountAttr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttrValueId",
                schema: "dbo",
                table: "AccountAttr",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountAttr_AttrId1",
                schema: "dbo",
                table: "AccountAttr",
                column: "AttrId1");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAttr_AttrValueId",
                schema: "dbo",
                table: "AccountAttr",
                column: "AttrValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAttr_Attr_AttrId1",
                schema: "dbo",
                table: "AccountAttr",
                column: "AttrId1",
                principalSchema: "dbo",
                principalTable: "Attr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAttr_AttrValue_AttrValueId",
                schema: "dbo",
                table: "AccountAttr",
                column: "AttrValueId",
                principalSchema: "dbo",
                principalTable: "AttrValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
