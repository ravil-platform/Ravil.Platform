using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class FixUpdateAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_JobBranch_Job_JobId1",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropIndex(
                name: "IX_JobBranch_JobId1",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropIndex(
                name: "IX_Address_JobBranchId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CanonicalMeta",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "IndexMeta",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "MetaDesc",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "JobId1",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                schema: "dbo",
                table: "JobBranch",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.CreateTable(
                name: "JobBranchShortLink",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortKey = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBranchShortLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobBranchShortLink_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobBranch_JobId",
                schema: "dbo",
                table: "JobBranch",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_JobBranchId",
                schema: "dbo",
                table: "Address",
                column: "JobBranchId",
                unique: true,
                filter: "[JobBranchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchShortLink_JobBranchId",
                schema: "dbo",
                table: "JobBranchShortLink",
                column: "JobBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Address",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranch_Job_JobId",
                schema: "dbo",
                table: "JobBranch",
                column: "JobId",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_JobBranch_Job_JobId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropTable(
                name: "JobBranchShortLink",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_JobBranch_JobId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropIndex(
                name: "IX_Address_JobBranchId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.AddColumn<bool>(
                name: "CanonicalMeta",
                schema: "dbo",
                table: "Location",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IndexMeta",
                schema: "dbo",
                table: "Location",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MetaDesc",
                schema: "dbo",
                table: "Location",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                schema: "dbo",
                table: "Location",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JobId1",
                schema: "dbo",
                table: "JobBranch",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobBranch_JobId1",
                schema: "dbo",
                table: "JobBranch",
                column: "JobId1");

            migrationBuilder.CreateIndex(
                name: "IX_Address_JobBranchId",
                schema: "dbo",
                table: "Address",
                column: "JobBranchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Address",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranch_Job_JobId1",
                schema: "dbo",
                table: "JobBranch",
                column: "JobId1",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
