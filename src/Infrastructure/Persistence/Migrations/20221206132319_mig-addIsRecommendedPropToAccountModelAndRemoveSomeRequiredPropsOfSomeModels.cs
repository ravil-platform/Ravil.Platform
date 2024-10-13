using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class migaddIsRecommendedPropToAccountModelAndRemoveSomeRequiredPropsOfSomeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AccountLevel_AccountLevelId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "SearchLink",
                schema: "dbo",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AlternateTitle",
                schema: "dbo",
                table: "Brand",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<int>(
                name: "AccountLevelId",
                schema: "dbo",
                table: "Account",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecommended",
                schema: "dbo",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AccountLevel_AccountLevelId",
                schema: "dbo",
                table: "Account",
                column: "AccountLevelId",
                principalSchema: "dbo",
                principalTable: "AccountLevel",
                principalColumn: "AccountLevelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AccountLevel_AccountLevelId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "IsRecommended",
                schema: "dbo",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "SearchLink",
                schema: "dbo",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AlternateTitle",
                schema: "dbo",
                table: "Brand",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountLevelId",
                schema: "dbo",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AccountLevel_AccountLevelId",
                schema: "dbo",
                table: "Account",
                column: "AccountLevelId",
                principalSchema: "dbo",
                principalTable: "AccountLevel",
                principalColumn: "AccountLevelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
