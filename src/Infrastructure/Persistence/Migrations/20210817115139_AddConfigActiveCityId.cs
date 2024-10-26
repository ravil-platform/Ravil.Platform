using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class AddConfigActiveCityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banner_AspNetUsers_UserId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_Banner_Category_CategoryId1",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_Banner_Job_JobId1",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBannerClick_Banner_BannerId1",
                schema: "dbo",
                table: "UserBannerClick");

            migrationBuilder.DropIndex(
                name: "IX_UserBannerClick_BannerId1",
                schema: "dbo",
                table: "UserBannerClick");

            migrationBuilder.DropIndex(
                name: "IX_Banner_CategoryId1",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropIndex(
                name: "IX_Banner_JobId1",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropIndex(
                name: "IX_Banner_UserId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "BannerId1",
                schema: "dbo",
                table: "UserBannerClick");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "JobId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "JobId1",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.RenameColumn(
                name: "UserLikedType",
                schema: "dbo",
                table: "UserBookMark",
                newName: "UserBookMarkType");

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "UserLikedGallery",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "UserBookMark",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BannerId",
                schema: "dbo",
                table: "UserBannerClick",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ActiveBaseCityId",
                schema: "dbo",
                table: "Config",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricingAccountDescription",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "SendNotificationState",
                schema: "dbo",
                table: "Config",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<string>(
                name: "SmallPicture",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LargePicture",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BannerType",
                schema: "dbo",
                table: "Banner",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                schema: "dbo",
                table: "Banner",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserBannerView",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBannerView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBannerView_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBannerView_Banner_BannerId",
                        column: x => x.BannerId,
                        principalSchema: "dbo",
                        principalTable: "Banner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Config",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActiveBaseCityId", "SendNotificationState" },
                values: new object[] { 245, (byte)1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserBannerClick_BannerId",
                schema: "dbo",
                table: "UserBannerClick",
                column: "BannerId");

            migrationBuilder.CreateIndex(
                name: "IX_Banner_JobBranchId",
                schema: "dbo",
                table: "Banner",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBannerView_BannerId",
                schema: "dbo",
                table: "UserBannerView",
                column: "BannerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBannerView_UserId",
                schema: "dbo",
                table: "UserBannerView",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banner_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Banner",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBannerClick_Banner_BannerId",
                schema: "dbo",
                table: "UserBannerClick",
                column: "BannerId",
                principalSchema: "dbo",
                principalTable: "Banner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banner_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBannerClick_Banner_BannerId",
                schema: "dbo",
                table: "UserBannerClick");

            migrationBuilder.DropTable(
                name: "UserBannerView",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_UserBannerClick_BannerId",
                schema: "dbo",
                table: "UserBannerClick");

            migrationBuilder.DropIndex(
                name: "IX_Banner_JobBranchId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "ActiveBaseCityId",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "PricingAccountDescription",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "SendNotificationState",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "JobBranchId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.RenameColumn(
                name: "UserBookMarkType",
                schema: "dbo",
                table: "UserBookMark",
                newName: "UserLikedType");

            migrationBuilder.AlterColumn<int>(
                name: "JobBranchId",
                schema: "dbo",
                table: "UserLikedGallery",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobBranchId",
                schema: "dbo",
                table: "UserBookMark",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BannerId",
                schema: "dbo",
                table: "UserBannerClick",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BannerId1",
                schema: "dbo",
                table: "UserBannerClick",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmallPicture",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LargePicture",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BannerType",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                schema: "dbo",
                table: "Banner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobId",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JobId1",
                schema: "dbo",
                table: "Banner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserBannerClick_BannerId1",
                schema: "dbo",
                table: "UserBannerClick",
                column: "BannerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Banner_CategoryId1",
                schema: "dbo",
                table: "Banner",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Banner_JobId1",
                schema: "dbo",
                table: "Banner",
                column: "JobId1");

            migrationBuilder.CreateIndex(
                name: "IX_Banner_UserId",
                schema: "dbo",
                table: "Banner",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banner_AspNetUsers_UserId",
                schema: "dbo",
                table: "Banner",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Banner_Category_CategoryId1",
                schema: "dbo",
                table: "Banner",
                column: "CategoryId1",
                principalSchema: "dbo",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Banner_Job_JobId1",
                schema: "dbo",
                table: "Banner",
                column: "JobId1",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBannerClick_Banner_BannerId1",
                schema: "dbo",
                table: "UserBannerClick",
                column: "BannerId1",
                principalSchema: "dbo",
                principalTable: "Banner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
