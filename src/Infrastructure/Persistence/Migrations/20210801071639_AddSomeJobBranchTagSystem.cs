using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddSomeJobBranchTagSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_AspNetUsers_UserOwnerId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFeedbackSlider_Job_JobId1",
                schema: "dbo",
                table: "UsersFeedbackSlider");

            migrationBuilder.DropIndex(
                name: "IX_UsersFeedbackSlider_JobId1",
                schema: "dbo",
                table: "UsersFeedbackSlider");

            migrationBuilder.DropIndex(
                name: "IX_Job_UserOwnerId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "JobId1",
                schema: "dbo",
                table: "UsersFeedbackSlider");

            migrationBuilder.DropColumn(
                name: "ConfirmationDate",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsAdminCreator",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsConfirmedByAdmin",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsOffer",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "UserOwnerId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                schema: "dbo",
                table: "UsersFeedbackSlider",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconHtmlCode",
                schema: "dbo",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconPicture",
                schema: "dbo",
                table: "Tag",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdminCreator",
                schema: "dbo",
                table: "JobBranch",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOffer",
                schema: "dbo",
                table: "JobBranch",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserOwnerId",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialName",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryService",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryService_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "dbo",
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobBranchTag",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBranchTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobBranchTag_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobBranchTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "dbo",
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTag",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTag_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "dbo",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "dbo",
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobBranch_UserOwnerId",
                schema: "dbo",
                table: "JobBranch",
                column: "UserOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryService_CategoryId",
                schema: "dbo",
                table: "CategoryService",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryService_ServiceId",
                schema: "dbo",
                table: "CategoryService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchTag_JobBranchId",
                schema: "dbo",
                table: "JobBranchTag",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchTag_TagId",
                schema: "dbo",
                table: "JobBranchTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTag_JobId",
                schema: "dbo",
                table: "JobTag",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTag_TagId",
                schema: "dbo",
                table: "JobTag",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranch_AspNetUsers_UserOwnerId",
                schema: "dbo",
                table: "JobBranch",
                column: "UserOwnerId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobBranch_AspNetUsers_UserOwnerId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropTable(
                name: "CategoryService",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobBranchTag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobTag",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_JobBranch_UserOwnerId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "IconHtmlCode",
                schema: "dbo",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "IconPicture",
                schema: "dbo",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "IsAdminCreator",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "IsOffer",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "UserOwnerId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "SocialName",
                schema: "dbo",
                table: "Job");

            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                schema: "dbo",
                table: "UsersFeedbackSlider",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JobId1",
                schema: "dbo",
                table: "UsersFeedbackSlider",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationDate",
                schema: "dbo",
                table: "Job",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdminCreator",
                schema: "dbo",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmedByAdmin",
                schema: "dbo",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOffer",
                schema: "dbo",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserOwnerId",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFeedbackSlider_JobId1",
                schema: "dbo",
                table: "UsersFeedbackSlider",
                column: "JobId1");

            migrationBuilder.CreateIndex(
                name: "IX_Job_UserOwnerId",
                schema: "dbo",
                table: "Job",
                column: "UserOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_AspNetUsers_UserOwnerId",
                schema: "dbo",
                table: "Job",
                column: "UserOwnerId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFeedbackSlider_Job_JobId1",
                schema: "dbo",
                table: "UsersFeedbackSlider",
                column: "JobId1",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
