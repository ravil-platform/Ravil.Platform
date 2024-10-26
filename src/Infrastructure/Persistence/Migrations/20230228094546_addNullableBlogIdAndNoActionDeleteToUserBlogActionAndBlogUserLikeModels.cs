using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class addNullableBlogIdAndNoActionDeleteToUserBlogActionAndBlogUserLikeModels : Migration
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
