using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class migremoveApplicationUserIdPropFromUserBookMarkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookMark_AspNetUsers_ApplicationUserId",
                schema: "dbo",
                table: "UserBookMark");

            migrationBuilder.DropIndex(
                name: "IX_UserBookMark_ApplicationUserId",
                schema: "dbo",
                table: "UserBookMark");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "dbo",
                table: "UserBookMark");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookMark_UserId",
                schema: "dbo",
                table: "UserBookMark",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookMark_AspNetUsers_UserId",
                schema: "dbo",
                table: "UserBookMark",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookMark_AspNetUsers_UserId",
                schema: "dbo",
                table: "UserBookMark");

            migrationBuilder.DropIndex(
                name: "IX_UserBookMark_UserId",
                schema: "dbo",
                table: "UserBookMark");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "dbo",
                table: "UserBookMark",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBookMark_ApplicationUserId",
                schema: "dbo",
                table: "UserBookMark",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookMark_AspNetUsers_ApplicationUserId",
                schema: "dbo",
                table: "UserBookMark",
                column: "ApplicationUserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
