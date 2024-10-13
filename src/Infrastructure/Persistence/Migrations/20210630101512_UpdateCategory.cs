using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attr_Category_CategoryId",
                schema: "dbo",
                table: "Attr");

            migrationBuilder.DropTable(
                name: "JobCategoryAttr",
                schema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Attr",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attr_Category_CategoryId",
                schema: "dbo",
                table: "Attr",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attr_Category_CategoryId",
                schema: "dbo",
                table: "Attr");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Attr",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "JobCategoryAttr",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttrId = table.Column<int>(type: "int", nullable: false),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategoryAttr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobCategoryAttr_Attr_AttrId",
                        column: x => x.AttrId,
                        principalSchema: "dbo",
                        principalTable: "Attr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCategoryAttr_JobCategory_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalSchema: "dbo",
                        principalTable: "JobCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCategoryAttr_AttrId",
                schema: "dbo",
                table: "JobCategoryAttr",
                column: "AttrId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCategoryAttr_JobCategoryId",
                schema: "dbo",
                table: "JobCategoryAttr",
                column: "JobCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attr_Category_CategoryId",
                schema: "dbo",
                table: "Attr",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
