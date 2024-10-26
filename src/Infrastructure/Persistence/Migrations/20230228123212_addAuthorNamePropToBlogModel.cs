using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class addAuthorNamePropToBlogModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_AspNetUsers_ApplicationUserId",
                schema: "dbo",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBlogAction_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogAction");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBlogLike_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogLike");

            migrationBuilder.DropIndex(
                name: "IX_Blog_ApplicationUserId",
                schema: "dbo",
                table: "Blog");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                schema: "dbo",
                table: "UserBlogLike",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                schema: "dbo",
                table: "UserBlogAction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBlogAction_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogAction",
                column: "BlogId",
                principalSchema: "dbo",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBlogLike_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogLike",
                column: "BlogId",
                principalSchema: "dbo",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBlogAction_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogAction");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBlogLike_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogLike");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                schema: "dbo",
                table: "Blog");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                schema: "dbo",
                table: "UserBlogLike",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                schema: "dbo",
                table: "UserBlogAction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_ApplicationUserId",
                schema: "dbo",
                table: "Blog",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_AspNetUsers_ApplicationUserId",
                schema: "dbo",
                table: "Blog",
                column: "ApplicationUserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBlogAction_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogAction",
                column: "BlogId",
                principalSchema: "dbo",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBlogLike_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogLike",
                column: "BlogId",
                principalSchema: "dbo",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
