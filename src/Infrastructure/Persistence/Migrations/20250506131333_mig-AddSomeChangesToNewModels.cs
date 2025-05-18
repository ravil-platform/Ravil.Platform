using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migAddSomeChangesToNewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payment_UserSubscriptionId",
                schema: "Payment",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_JobInfo_JobId",
                schema: "Job",
                table: "JobInfo");

            migrationBuilder.DropColumn(
                name: "CostPerClick",
                schema: "Job",
                table: "JobKeyword");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinally",
                schema: "Subscription",
                table: "UserSubscription",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "CostPerClick",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeposit",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "KeywordId",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "KeywordPageTitle",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeywordPageUrl",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeywordSlug",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                schema: "Subscription",
                table: "SubscriptionClick",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "Discount",
                schema: "Subscription",
                table: "Subscription",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DiscountAmount",
                schema: "Subscription",
                table: "Subscription",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "Payment",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "CanonicalMeta",
                schema: "Job",
                table: "Keyword",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Job",
                table: "Keyword",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IndexMeta",
                schema: "Job",
                table: "Keyword",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Job",
                table: "Keyword",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Job",
                table: "Keyword",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Job",
                table: "Keyword",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Job",
                table: "Keyword",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "Job",
                table: "Keyword",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDesc",
                schema: "Job",
                table: "Keyword",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                schema: "Job",
                table: "Keyword",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                schema: "Job",
                table: "JobInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ZarinpalCallbackUrl",
                schema: "Shared",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DownVoteLastUpdate",
                schema: "Comment",
                table: "Comment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DownVotesCount",
                schema: "Comment",
                table: "Comment",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Rate",
                schema: "Comment",
                table: "Comment",
                type: "tinyint",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpVoteLastUpdate",
                schema: "Comment",
                table: "Comment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpVotesCount",
                schema: "Comment",
                table: "Comment",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 6, 16, 43, 31, 419, DateTimeKind.Local).AddTicks(8381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 28, 9, 57, 53, 138, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.AddColumn<string>(
                name: "PageSlug",
                schema: "Shared",
                table: "ActionHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PageTitle",
                schema: "Shared",
                table: "ActionHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PageUrl",
                schema: "Shared",
                table: "ActionHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ClickAdsSetting",
                schema: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AdDisplayRange = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    MaxCostPerClick = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClickAdsSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClickAdsSetting_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentInteraction",
                schema: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Liked = table.Column<bool>(type: "bit", nullable: false),
                    DisLiked = table.Column<bool>(type: "bit", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentInteraction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentInteraction_Comment_CommentId",
                        column: x => x.CommentId,
                        principalSchema: "Comment",
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobRankingHistory",
                schema: "Job",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRankingHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRankingHistory_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "Job",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "7a1221eb-07a6-420c-916c-2f794922e923", "AQAAAAIAAYagAAAAEMGrLGztCIL2mnrEPgqfm9mgRyIXfuzDf23ytcHe240Vfod+2pPhXTGV5Fez8AwHpA==", new DateTime(2025, 5, 6, 16, 43, 31, 438, DateTimeKind.Local).AddTicks(5206), "cdbff965-4c05-454a-b649-efbf67bf9483" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "09714f75-eff5-4d22-af0e-ff7dd8df1d5c", "AQAAAAIAAYagAAAAECrxgLCSamTmKl7AnFPM4l24Uv/dCQjMhlhnIFWGUb9spVSWkxaUVQ1lmc+MISRUGQ==", new DateTime(2025, 5, 6, 16, 43, 31, 485, DateTimeKind.Local).AddTicks(1813), "781b5d99-ec1b-47e6-bf7b-062a94f2b527" });

            migrationBuilder.UpdateData(
                schema: "Shared",
                table: "Config",
                keyColumn: "Id",
                keyValue: 1,
                column: "ZarinpalCallbackUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discount", "DiscountAmount" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discount", "DiscountAmount" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Discount", "DiscountAmount" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Discount", "DiscountAmount" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Discount", "DiscountAmount" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "Subscription",
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Discount", "DiscountAmount" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionClick_JobId",
                schema: "Subscription",
                table: "SubscriptionClick",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserSubscriptionId",
                schema: "Payment",
                table: "Payment",
                column: "UserSubscriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keyword_Slug",
                schema: "Job",
                table: "Keyword",
                column: "Slug",
                filter: "[Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobInfo_JobId",
                schema: "Job",
                table: "JobInfo",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ClickAdsSetting_UserId",
                schema: "Job",
                table: "ClickAdsSetting",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentInteraction_CommentId",
                schema: "Comment",
                table: "CommentInteraction",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRankingHistory_JobId",
                schema: "Job",
                table: "JobRankingHistory",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionClick_Job_JobId",
                schema: "Subscription",
                table: "SubscriptionClick",
                column: "JobId",
                principalSchema: "Job",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionClick_Job_JobId",
                schema: "Subscription",
                table: "SubscriptionClick");

            migrationBuilder.DropTable(
                name: "ClickAdsSetting",
                schema: "Job");

            migrationBuilder.DropTable(
                name: "CommentInteraction",
                schema: "Comment");

            migrationBuilder.DropTable(
                name: "JobRankingHistory",
                schema: "Job");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionClick_JobId",
                schema: "Subscription",
                table: "SubscriptionClick");

            migrationBuilder.DropIndex(
                name: "IX_Payment_UserSubscriptionId",
                schema: "Payment",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Keyword_Slug",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropIndex(
                name: "IX_JobInfo_JobId",
                schema: "Job",
                table: "JobInfo");

            migrationBuilder.DropColumn(
                name: "IsFinally",
                schema: "Subscription",
                table: "UserSubscription");

            migrationBuilder.DropColumn(
                name: "CostPerClick",
                schema: "Subscription",
                table: "SubscriptionClick");

            migrationBuilder.DropColumn(
                name: "IsDeposit",
                schema: "Subscription",
                table: "SubscriptionClick");

            migrationBuilder.DropColumn(
                name: "JobId",
                schema: "Subscription",
                table: "SubscriptionClick");

            migrationBuilder.DropColumn(
                name: "KeywordId",
                schema: "Subscription",
                table: "SubscriptionClick");

            migrationBuilder.DropColumn(
                name: "KeywordPageTitle",
                schema: "Subscription",
                table: "SubscriptionClick");

            migrationBuilder.DropColumn(
                name: "KeywordPageUrl",
                schema: "Subscription",
                table: "SubscriptionClick");

            migrationBuilder.DropColumn(
                name: "KeywordSlug",
                schema: "Subscription",
                table: "SubscriptionClick");

            migrationBuilder.DropColumn(
                name: "Position",
                schema: "Subscription",
                table: "SubscriptionClick");

            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "Subscription",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                schema: "Subscription",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "Number",
                schema: "Payment",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CanonicalMeta",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "IndexMeta",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "MetaCanonicalUrl",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "MetaDesc",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                schema: "Job",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                schema: "Job",
                table: "JobInfo");

            migrationBuilder.DropColumn(
                name: "ZarinpalCallbackUrl",
                schema: "Shared",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "DownVoteLastUpdate",
                schema: "Comment",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "DownVotesCount",
                schema: "Comment",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Rate",
                schema: "Comment",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UpVoteLastUpdate",
                schema: "Comment",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UpVotesCount",
                schema: "Comment",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "PageSlug",
                schema: "Shared",
                table: "ActionHistories");

            migrationBuilder.DropColumn(
                name: "PageTitle",
                schema: "Shared",
                table: "ActionHistories");

            migrationBuilder.DropColumn(
                name: "PageUrl",
                schema: "Shared",
                table: "ActionHistories");

            migrationBuilder.AddColumn<int>(
                name: "CostPerClick",
                schema: "Job",
                table: "JobKeyword",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 28, 9, 57, 53, 138, DateTimeKind.Local).AddTicks(2742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 6, 16, 43, 31, 419, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "0eace3dd-45a1-47c0-a5c8-12fbbce2cccb", "AQAAAAIAAYagAAAAEEcI+8Cg0MiG0m1thIwwBbH9RjZxOPCZrF7e+s1QtFgK9yHSP3W/T26w/mGH1BTHHQ==", new DateTime(2025, 4, 28, 9, 57, 53, 154, DateTimeKind.Local).AddTicks(6043), "dce27e4d-8d9b-4e32-8068-04bd5a7dcc8b" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "dc514388-75dc-422d-bb24-53d1cd4e1ab9", "AQAAAAIAAYagAAAAENhPtHCDRvsJYWCfvyNOfR6Pb5sw13Z2UHf7naz9zUdwqOHFFJPofrXkp+O3z6IwbA==", new DateTime(2025, 4, 28, 9, 57, 53, 202, DateTimeKind.Local).AddTicks(7164), "05809709-a83c-4b34-8e2b-4d2051e5f53e" });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserSubscriptionId",
                schema: "Payment",
                table: "Payment",
                column: "UserSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInfo_JobId",
                schema: "Job",
                table: "JobInfo",
                column: "JobId",
                unique: true);
        }
    }
}
