using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class JobBrandIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Brand_JobBrandId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.AlterColumn<int>(
                name: "JobBrandId",
                schema: "dbo",
                table: "Job",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Brand_JobBrandId",
                schema: "dbo",
                table: "Job",
                column: "JobBrandId",
                principalSchema: "dbo",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Brand_JobBrandId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.AlterColumn<int>(
                name: "JobBrandId",
                schema: "dbo",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Brand_JobBrandId",
                schema: "dbo",
                table: "Job",
                column: "JobBrandId",
                principalSchema: "dbo",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
