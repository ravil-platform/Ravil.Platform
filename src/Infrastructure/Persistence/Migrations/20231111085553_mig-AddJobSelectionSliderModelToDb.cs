using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class migAddJobSelectionSliderModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobSelectionSlider",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobSliderType = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSelectionSlider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSelectionSlider_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSelectionSlider_JobBranchId",
                schema: "dbo",
                table: "JobSelectionSlider",
                column: "JobBranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSelectionSlider",
                schema: "dbo");
        }
    }
}
