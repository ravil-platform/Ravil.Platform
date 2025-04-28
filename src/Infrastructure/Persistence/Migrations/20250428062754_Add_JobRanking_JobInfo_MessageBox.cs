using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_JobRanking_JobInfo_MessageBox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Shared");

            migrationBuilder.EnsureSchema(
                name: "Address");

            migrationBuilder.EnsureSchema(
                name: "Comment");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.EnsureSchema(
                name: "Blog");

            migrationBuilder.EnsureSchema(
                name: "Job");

            migrationBuilder.EnsureSchema(
                name: "Category");

            migrationBuilder.EnsureSchema(
                name: "City");

            migrationBuilder.EnsureSchema(
                name: "Subscription");

            migrationBuilder.EnsureSchema(
                name: "Contact");

            migrationBuilder.EnsureSchema(
                name: "Faq");

            migrationBuilder.EnsureSchema(
                name: "Payment");

            migrationBuilder.EnsureSchema(
                name: "State");

            migrationBuilder.EnsureSchema(
                name: "Tag");

            migrationBuilder.EnsureSchema(
                name: "Wallet");

            migrationBuilder.RenameTable(
                name: "WalletTransaction",
                schema: "dbo",
                newName: "WalletTransaction",
                newSchema: "Wallet");

            migrationBuilder.RenameTable(
                name: "Wallet",
                schema: "dbo",
                newName: "Wallet",
                newSchema: "Wallet");

            migrationBuilder.RenameTable(
                name: "UserSubscription",
                schema: "dbo",
                newName: "UserSubscription",
                newSchema: "Subscription");

            migrationBuilder.RenameTable(
                name: "UsersToken",
                schema: "dbo",
                newName: "UsersToken",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "UserBookMark",
                schema: "dbo",
                newName: "UserBookMark",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "UserBlogLike",
                schema: "dbo",
                newName: "UserBlogLike",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "UserBannerView",
                schema: "dbo",
                newName: "UserBannerView",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "UserBannerClick",
                schema: "dbo",
                newName: "UserBannerClick",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "UserAddresses",
                schema: "dbo",
                newName: "UserAddresses",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "UploadedFile",
                schema: "dbo",
                newName: "UploadedFile",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "Transaction",
                schema: "dbo",
                newName: "Transaction",
                newSchema: "Wallet");

            migrationBuilder.RenameTable(
                name: "Team",
                schema: "dbo",
                newName: "Team",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "Target",
                schema: "dbo",
                newName: "Target",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "Tag",
                schema: "dbo",
                newName: "Tag",
                newSchema: "Tag");

            migrationBuilder.RenameTable(
                name: "SubscriptionFeature",
                schema: "dbo",
                newName: "SubscriptionFeature",
                newSchema: "Subscription");

            migrationBuilder.RenameTable(
                name: "SubscriptionClick",
                schema: "dbo",
                newName: "SubscriptionClick",
                newSchema: "Subscription");

            migrationBuilder.RenameTable(
                name: "Subscription",
                schema: "dbo",
                newName: "Subscription",
                newSchema: "Subscription");

            migrationBuilder.RenameTable(
                name: "StateBase",
                schema: "dbo",
                newName: "StateBase",
                newSchema: "State");

            migrationBuilder.RenameTable(
                name: "State",
                schema: "dbo",
                newName: "State",
                newSchema: "State");

            migrationBuilder.RenameTable(
                name: "ShortLink",
                schema: "dbo",
                newName: "ShortLink",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "Service",
                schema: "dbo",
                newName: "Service",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "RelatedCategorySeo",
                schema: "dbo",
                newName: "RelatedCategorySeo",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "RedirectionUrl",
                schema: "dbo",
                newName: "RedirectionUrl",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "PromotionCode",
                schema: "dbo",
                newName: "PromotionCode",
                newSchema: "Payment");

            migrationBuilder.RenameTable(
                name: "PaymentPortal",
                schema: "dbo",
                newName: "PaymentPortal",
                newSchema: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                schema: "dbo",
                newName: "Payment",
                newSchema: "Payment");

            migrationBuilder.RenameTable(
                name: "PanelTutorial",
                schema: "dbo",
                newName: "PanelTutorial",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "MainSlider",
                schema: "dbo",
                newName: "MainSlider",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "Location",
                schema: "dbo",
                newName: "Location",
                newSchema: "Address");

            migrationBuilder.RenameTable(
                name: "Keyword",
                schema: "dbo",
                newName: "Keyword",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobTimeWork",
                schema: "dbo",
                newName: "JobTimeWork",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobTag",
                schema: "dbo",
                newName: "JobTag",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobService",
                schema: "dbo",
                newName: "JobService",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobSelectionSlider",
                schema: "dbo",
                newName: "JobSelectionSlider",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobKeyword",
                schema: "dbo",
                newName: "JobKeyword",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobBranchTag",
                schema: "dbo",
                newName: "JobBranchTag",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobBranchShortLink",
                schema: "dbo",
                newName: "JobBranchShortLink",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobBranchRelatedJob",
                schema: "dbo",
                newName: "JobBranchRelatedJob",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobBranchGallery",
                schema: "dbo",
                newName: "JobBranchGallery",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobBranchAds",
                schema: "dbo",
                newName: "JobBranchAds",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "JobBranch",
                schema: "dbo",
                newName: "JobBranch",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "Job",
                schema: "dbo",
                newName: "Job",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "FeedbackSlider",
                schema: "dbo",
                newName: "FeedbackSlider",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "Feature",
                schema: "dbo",
                newName: "Feature",
                newSchema: "Subscription");

            migrationBuilder.RenameTable(
                name: "FaqJobCategory",
                schema: "dbo",
                newName: "FaqJobCategory",
                newSchema: "Faq");

            migrationBuilder.RenameTable(
                name: "FaqCategory",
                schema: "dbo",
                newName: "FaqCategory",
                newSchema: "Faq");

            migrationBuilder.RenameTable(
                name: "Faq",
                schema: "dbo",
                newName: "Faq",
                newSchema: "Faq");

            migrationBuilder.RenameTable(
                name: "ContactUs",
                schema: "dbo",
                newName: "ContactUs",
                newSchema: "Contact");

            migrationBuilder.RenameTable(
                name: "Config",
                schema: "dbo",
                newName: "Config",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "Comment",
                schema: "dbo",
                newName: "Comment",
                newSchema: "Comment");

            migrationBuilder.RenameTable(
                name: "Click",
                schema: "dbo",
                newName: "Click",
                newSchema: "Subscription");

            migrationBuilder.RenameTable(
                name: "CityCategory",
                schema: "dbo",
                newName: "CityCategory",
                newSchema: "City");

            migrationBuilder.RenameTable(
                name: "CityBase",
                schema: "dbo",
                newName: "CityBase",
                newSchema: "City");

            migrationBuilder.RenameTable(
                name: "City",
                schema: "dbo",
                newName: "City",
                newSchema: "City");

            migrationBuilder.RenameTable(
                name: "CategoryTag",
                schema: "dbo",
                newName: "CategoryTag",
                newSchema: "Category");

            migrationBuilder.RenameTable(
                name: "CategoryService",
                schema: "dbo",
                newName: "CategoryService",
                newSchema: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "dbo",
                newName: "Category",
                newSchema: "Category");

            migrationBuilder.RenameTable(
                name: "CategoriesCityContent",
                schema: "dbo",
                newName: "CategoriesCityContent",
                newSchema: "Job");

            migrationBuilder.RenameTable(
                name: "Brand",
                schema: "dbo",
                newName: "Brand",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "BlogTag",
                schema: "dbo",
                newName: "BlogTag",
                newSchema: "Blog");

            migrationBuilder.RenameTable(
                name: "BlogCategoryRel",
                schema: "dbo",
                newName: "BlogCategoryRel",
                newSchema: "Blog");

            migrationBuilder.RenameTable(
                name: "BlogCategory",
                schema: "dbo",
                newName: "BlogCategory",
                newSchema: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                schema: "dbo",
                newName: "Blog",
                newSchema: "Blog");

            migrationBuilder.RenameTable(
                name: "Banner",
                schema: "dbo",
                newName: "Banner",
                newSchema: "Shared");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                schema: "dbo",
                newName: "ApplicationUser",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "AnswerComment",
                schema: "dbo",
                newName: "AnswerComment",
                newSchema: "Comment");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "dbo",
                newName: "Address",
                newSchema: "Address");

            migrationBuilder.RenameTable(
                name: "ActionHistories",
                schema: "dbo",
                newName: "ActionHistories",
                newSchema: "Shared");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Payment",
                table: "PaymentPortal",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Address",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 28, 9, 57, 53, 138, DateTimeKind.Local).AddTicks(2742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 16, 14, 43, 12, 444, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.CreateTable(
                name: "JobInfo",
                schema: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visit = table.Column<int>(type: "int", nullable: false),
                    ClickOnCard = table.Column<int>(type: "int", nullable: false),
                    ClickOnCall = table.Column<int>(type: "int", nullable: false),
                    ClickOnMap = table.Column<int>(type: "int", nullable: false),
                    ClickOnChat = table.Column<int>(type: "int", nullable: false),
                    ClickOnImages = table.Column<int>(type: "int", nullable: false),
                    ClickOnWebSite = table.Column<int>(type: "int", nullable: false),
                    AverageClickOnCall = table.Column<double>(type: "float", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobInfo_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "Job",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobRanking",
                schema: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AveragePosition = table.Column<double>(type: "float", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRanking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRanking_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "Job",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageBox",
                schema: "Shared",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageBox_Job_JobId",
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
                values: new object[] { "0eace3dd-45a1-47c0-a5c8-12fbbce2cccb", "AQAAAAIAAYagAAAAEEcI+8Cg0MiG0m1thIwwBbH9RjZxOPCZrF7e+s1QtFgK9yHSP3W/T26w/mGH1BTHHQ==", new DateTime(2025, 4, 28, 9, 57, 53, 154, DateTimeKind.Local).AddTicks(6043), "dce27e4d-8d9b-4e32-8068-04bd5a7dcc8b" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "dc514388-75dc-422d-bb24-53d1cd4e1ab9", "AQAAAAIAAYagAAAAENhPtHCDRvsJYWCfvyNOfR6Pb5sw13Z2UHf7naz9zUdwqOHFFJPofrXkp+O3z6IwbA==", new DateTime(2025, 4, 28, 9, 57, 53, 202, DateTimeKind.Local).AddTicks(7164), "05809709-a83c-4b34-8e2b-4d2051e5f53e" });

            migrationBuilder.CreateIndex(
                name: "IX_JobInfo_JobId",
                schema: "Job",
                table: "JobInfo",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobRanking_JobId",
                schema: "Job",
                table: "JobRanking",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageBox_JobId",
                schema: "Shared",
                table: "MessageBox",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobInfo",
                schema: "Job");

            migrationBuilder.DropTable(
                name: "JobRanking",
                schema: "Job");

            migrationBuilder.DropTable(
                name: "MessageBox",
                schema: "Shared");

            migrationBuilder.RenameTable(
                name: "WalletTransaction",
                schema: "Wallet",
                newName: "WalletTransaction",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Wallet",
                schema: "Wallet",
                newName: "Wallet",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserSubscription",
                schema: "Subscription",
                newName: "UserSubscription",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UsersToken",
                schema: "User",
                newName: "UsersToken",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserBookMark",
                schema: "User",
                newName: "UserBookMark",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserBlogLike",
                schema: "User",
                newName: "UserBlogLike",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserBannerView",
                schema: "User",
                newName: "UserBannerView",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserBannerClick",
                schema: "User",
                newName: "UserBannerClick",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserAddresses",
                schema: "User",
                newName: "UserAddresses",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UploadedFile",
                schema: "Shared",
                newName: "UploadedFile",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Transaction",
                schema: "Wallet",
                newName: "Transaction",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Team",
                schema: "Shared",
                newName: "Team",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Target",
                schema: "Job",
                newName: "Target",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Tag",
                schema: "Tag",
                newName: "Tag",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SubscriptionFeature",
                schema: "Subscription",
                newName: "SubscriptionFeature",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SubscriptionClick",
                schema: "Subscription",
                newName: "SubscriptionClick",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Subscription",
                schema: "Subscription",
                newName: "Subscription",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "StateBase",
                schema: "State",
                newName: "StateBase",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "State",
                schema: "State",
                newName: "State",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ShortLink",
                schema: "Shared",
                newName: "ShortLink",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Service",
                schema: "Shared",
                newName: "Service",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RelatedCategorySeo",
                schema: "Job",
                newName: "RelatedCategorySeo",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RedirectionUrl",
                schema: "Shared",
                newName: "RedirectionUrl",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PromotionCode",
                schema: "Payment",
                newName: "PromotionCode",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PaymentPortal",
                schema: "Payment",
                newName: "PaymentPortal",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Payment",
                schema: "Payment",
                newName: "Payment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PanelTutorial",
                schema: "Shared",
                newName: "PanelTutorial",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "MainSlider",
                schema: "Shared",
                newName: "MainSlider",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Location",
                schema: "Address",
                newName: "Location",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Keyword",
                schema: "Job",
                newName: "Keyword",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobTimeWork",
                schema: "Job",
                newName: "JobTimeWork",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobTag",
                schema: "Job",
                newName: "JobTag",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobService",
                schema: "Job",
                newName: "JobService",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobSelectionSlider",
                schema: "Job",
                newName: "JobSelectionSlider",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobKeyword",
                schema: "Job",
                newName: "JobKeyword",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranchTag",
                schema: "Job",
                newName: "JobBranchTag",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranchShortLink",
                schema: "Job",
                newName: "JobBranchShortLink",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranchRelatedJob",
                schema: "Job",
                newName: "JobBranchRelatedJob",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranchGallery",
                schema: "Job",
                newName: "JobBranchGallery",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranchAds",
                schema: "Job",
                newName: "JobBranchAds",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranch",
                schema: "Job",
                newName: "JobBranch",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Job",
                schema: "Job",
                newName: "Job",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FeedbackSlider",
                schema: "Shared",
                newName: "FeedbackSlider",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Feature",
                schema: "Subscription",
                newName: "Feature",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FaqJobCategory",
                schema: "Faq",
                newName: "FaqJobCategory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FaqCategory",
                schema: "Faq",
                newName: "FaqCategory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Faq",
                schema: "Faq",
                newName: "Faq",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ContactUs",
                schema: "Contact",
                newName: "ContactUs",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Config",
                schema: "Shared",
                newName: "Config",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Comment",
                schema: "Comment",
                newName: "Comment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Click",
                schema: "Subscription",
                newName: "Click",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CityCategory",
                schema: "City",
                newName: "CityCategory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CityBase",
                schema: "City",
                newName: "CityBase",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "City",
                schema: "City",
                newName: "City",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CategoryTag",
                schema: "Category",
                newName: "CategoryTag",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CategoryService",
                schema: "Category",
                newName: "CategoryService",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "Category",
                newName: "Category",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CategoriesCityContent",
                schema: "Job",
                newName: "CategoriesCityContent",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Brand",
                schema: "Shared",
                newName: "Brand",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BlogTag",
                schema: "Blog",
                newName: "BlogTag",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BlogCategoryRel",
                schema: "Blog",
                newName: "BlogCategoryRel",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BlogCategory",
                schema: "Blog",
                newName: "BlogCategory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Blog",
                schema: "Blog",
                newName: "Blog",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Banner",
                schema: "Shared",
                newName: "Banner",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                schema: "User",
                newName: "ApplicationUser",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AnswerComment",
                schema: "Comment",
                newName: "AnswerComment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "Address",
                newName: "Address",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ActionHistories",
                schema: "Shared",
                newName: "ActionHistories",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "PaymentPortal",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 16, 14, 43, 12, 444, DateTimeKind.Local).AddTicks(1925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 28, 9, 57, 53, 138, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "2c7040b6-e71a-4517-ac5e-f36fe8b2df56", "AQAAAAIAAYagAAAAEGmEDBvUGyqpScsORWRxYnevIARbhd2Qo2HvqfnVyPEv4J0p0XKMtLe0aK9l5ve0ZQ==", new DateTime(2025, 4, 16, 14, 43, 12, 460, DateTimeKind.Local).AddTicks(238), "6ee9b0ca-e57a-46c3-bac1-099601a0b85c" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "3a7310a6-0fc2-40ed-9874-4856c14018c1", "AQAAAAIAAYagAAAAEDzV0CsAgyHDsPwGce+mdkXjxEr7HjO0xvys3XfOt+AmhKXEtQaEEB/uwM0tsZ3HDw==", new DateTime(2025, 4, 16, 14, 43, 12, 505, DateTimeKind.Local).AddTicks(2739), "4bd00ad9-1716-4e65-96e9-748b6ef62e55" });
        }
    }
}
