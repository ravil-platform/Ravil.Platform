using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class updateFixSomeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCategory_Job_JobId1",
                schema: "dbo",
                table: "JobCategory");

            migrationBuilder.DropIndex(
                name: "IX_JobCategory_JobId1",
                schema: "dbo",
                table: "JobCategory");

            migrationBuilder.DropColumn(
                name: "JobId1",
                schema: "dbo",
                table: "JobCategory");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "dbo",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                schema: "dbo",
                table: "JobCategory",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.CreateTable(
                name: "FeedbackSlider",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackSlider", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCategory_JobId",
                schema: "dbo",
                table: "JobCategory",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCategory_Job_JobId",
                schema: "dbo",
                table: "JobCategory",
                column: "JobId",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCategory_Job_JobId",
                schema: "dbo",
                table: "JobCategory");

            migrationBuilder.DropTable(
                name: "FeedbackSlider",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_JobCategory_JobId",
                schema: "dbo",
                table: "JobCategory");

            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                schema: "dbo",
                table: "JobCategory",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JobId1",
                schema: "dbo",
                table: "JobCategory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                schema: "dbo",
                table: "Category",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_JobCategory_JobId1",
                schema: "dbo",
                table: "JobCategory",
                column: "JobId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCategory_Job_JobId1",
                schema: "dbo",
                table: "JobCategory",
                column: "JobId1",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
