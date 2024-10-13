using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addRestrictActionDeleteToUserBlogActionAndBlogUserLikeModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBlogAction_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogAction");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBlogLike_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogLike");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserBlogAction_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogAction",
                column: "BlogId",
                principalSchema: "dbo",
                principalTable: "Blog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBlogLike_Blog_BlogId",
                schema: "dbo",
                table: "UserBlogLike",
                column: "BlogId",
                principalSchema: "dbo",
                principalTable: "Blog",
                principalColumn: "Id");
        }
    }
}
