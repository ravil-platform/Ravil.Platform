using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class AddAttrOfAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAttr_Attr_AttrId",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountAttr_AttrValue_ValueId",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.AddColumn<bool>(
                name: "IsResizePicture",
                schema: "dbo",
                table: "State",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AttrAccountId",
                schema: "dbo",
                table: "AttrValue",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "AttrAccount",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AttrType = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<short>(type: "smallint", nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    IconHtmlCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttrCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttrAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttrAccount_AttrCategory_AttrCategoryId",
                        column: x => x.AttrCategoryId,
                        principalSchema: "dbo",
                        principalTable: "AttrCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttrAccountValue",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    AttrAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttrAccountValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttrAccountValue_AttrAccount_AttrAccountId",
                        column: x => x.AttrAccountId,
                        principalSchema: "dbo",
                        principalTable: "AttrAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttrValue_AttrAccountId",
                schema: "dbo",
                table: "AttrValue",
                column: "AttrAccountId");

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

            migrationBuilder.CreateIndex(
                name: "IX_AttrAccount_AttrCategoryId",
                schema: "dbo",
                table: "AttrAccount",
                column: "AttrCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AttrAccountValue_AttrAccountId",
                schema: "dbo",
                table: "AttrAccountValue",
                column: "AttrAccountId");

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
                name: "FK_AccountAttr_AttrAccount_AttrId",
                schema: "dbo",
                table: "AccountAttr",
                column: "AttrId",
                principalSchema: "dbo",
                principalTable: "AttrAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAttr_AttrAccountValue_ValueId",
                schema: "dbo",
                table: "AccountAttr",
                column: "ValueId",
                principalSchema: "dbo",
                principalTable: "AttrAccountValue",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAttr_AttrValue_AttrValueId",
                schema: "dbo",
                table: "AccountAttr",
                column: "AttrValueId",
                principalSchema: "dbo",
                principalTable: "AttrValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAttr_Attr_AttrId1",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountAttr_AttrAccount_AttrId",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountAttr_AttrAccountValue_ValueId",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountAttr_AttrValue_AttrValueId",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropForeignKey(
                name: "FK_AttrValue_AttrAccount_AttrAccountId",
                schema: "dbo",
                table: "AttrValue");

            migrationBuilder.DropTable(
                name: "AttrAccountValue",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttrAccount",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_AttrValue_AttrAccountId",
                schema: "dbo",
                table: "AttrValue");

            migrationBuilder.DropIndex(
                name: "IX_AccountAttr_AttrId1",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropIndex(
                name: "IX_AccountAttr_AttrValueId",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropColumn(
                name: "IsResizePicture",
                schema: "dbo",
                table: "State");

            migrationBuilder.DropColumn(
                name: "AttrAccountId",
                schema: "dbo",
                table: "AttrValue");

            migrationBuilder.DropColumn(
                name: "AttrId1",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.DropColumn(
                name: "AttrValueId",
                schema: "dbo",
                table: "AccountAttr");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAttr_Attr_AttrId",
                schema: "dbo",
                table: "AccountAttr",
                column: "AttrId",
                principalSchema: "dbo",
                principalTable: "Attr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAttr_AttrValue_ValueId",
                schema: "dbo",
                table: "AccountAttr",
                column: "ValueId",
                principalSchema: "dbo",
                principalTable: "AttrValue",
                principalColumn: "Id");
        }
    }
}
