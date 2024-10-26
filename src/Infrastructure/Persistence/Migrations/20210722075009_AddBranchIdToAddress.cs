using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class AddBranchIdToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobBranch_Address_AddressId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropIndex(
                name: "IX_JobBranch_AddressId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                defaultValue: "");

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
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_JobBranchId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "JobBranchId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranch_AddressId",
                schema: "dbo",
                table: "JobBranch",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranch_Address_AddressId",
                schema: "dbo",
                table: "JobBranch",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id");
        }
    }
}
