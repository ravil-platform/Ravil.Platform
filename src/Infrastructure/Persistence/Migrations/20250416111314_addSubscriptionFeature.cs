using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addSubscriptionFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAttr",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdminTheme",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobBranchAttr",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttrAccountValue",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttrValue",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttrAccount",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Attr",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AccountCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AccountLevel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttrCategory",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Picture",
                schema: "dbo",
                table: "PaymentPortal");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "dbo",
                table: "PaymentPortal",
                newName: "IsActive");

            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                schema: "dbo",
                table: "PaymentPortal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 16, 14, 43, 12, 444, DateTimeKind.Local).AddTicks(1925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 13, 9, 18, 57, 24, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.CreateTable(
                name: "Click",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    CostPerClick = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Click", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keyword",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keyword_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PanelTutorial",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    CoverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanelTutorial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    GiftCharge = table.Column<int>(type: "int", nullable: false),
                    DurationTime = table.Column<int>(type: "int", nullable: false),
                    DurationType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Inventory = table.Column<double>(type: "float", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobKeyword",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KeywordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostPerClick = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobKeyword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobKeyword_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobKeyword_Keyword_KeywordId",
                        column: x => x.KeywordId,
                        principalSchema: "dbo",
                        principalTable: "Keyword",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionClick",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ClickId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    ClickedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionClick", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionClick_Click_ClickId",
                        column: x => x.ClickId,
                        principalSchema: "dbo",
                        principalTable: "Click",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionClick_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "dbo",
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionFeature",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionFeature_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "dbo",
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionFeature_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "dbo",
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscription",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuyCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubscription_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubscription_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "dbo",
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    UserSubscriptionId = table.Column<int>(type: "int", nullable: false),
                    PaymentPortalId = table.Column<int>(type: "int", nullable: false),
                    PromotionCodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentPortal_PaymentPortalId",
                        column: x => x.PaymentPortalId,
                        principalSchema: "dbo",
                        principalTable: "PaymentPortal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_PromotionCode_PromotionCodeId",
                        column: x => x.PromotionCodeId,
                        principalSchema: "dbo",
                        principalTable: "PromotionCode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payment_UserSubscription_UserSubscriptionId",
                        column: x => x.UserSubscriptionId,
                        principalSchema: "dbo",
                        principalTable: "UserSubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    RefId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "dbo",
                        principalTable: "Payment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WalletTransaction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTransaction_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "dbo",
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletTransaction_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalSchema: "dbo",
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Click",
                columns: new[] { "Id", "CostPerClick", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 30000, "کلیک روی تبلیغات", 0 },
                    { 2, 15000, "کلیک روی مسیریابی", 2 },
                    { 3, 20000, "کلیک روی تماس", 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Subscription",
                columns: new[] { "Id", "DurationTime", "DurationType", "GiftCharge", "Icon", "IsActive", "Price", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, 90, 1, 250000, "empty.webp", true, 50000000, "برای کسب‌وکارهای متوسط که رقیب‌های زیادی ندارند.", "سه ماهه استاندارد" },
                    { 2, 180, 2, 500000, "empty.webp", true, 100000000, "برای کسب‌وکارهای متوسط که رقیب‌های زیادی ندارند.", "شش ماهه استاندارد" },
                    { 3, 365, 3, 1000000, "empty.webp", true, 200000000, "برای کسب‌وکارهای متوسط که رقیب‌های زیادی ندارند.", "یک ساله استاندارد" },
                    { 4, 90, 1, 2500000, "empty.webp", true, 500000000, "برای کسب‌وکارهای که رقیب‌های زیادی دارند.", "سه ماهه حرفه ای" },
                    { 5, 180, 2, 5000000, "empty.webp", true, 1000000000, "برای کسب‌وکارهای که رقیب‌های زیادی دارند.", "شش ماهه حرفه ای" },
                    { 6, 365, 3, 10000000, "empty.webp", true, 2000000000, "برای کسب‌وکارهای که رقیب‌های زیادی دارند.", "یک ساله حرفه ای" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobKeyword_JobBranchId",
                schema: "dbo",
                table: "JobKeyword",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JobKeyword_KeywordId",
                schema: "dbo",
                table: "JobKeyword",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyword_CategoryId",
                schema: "dbo",
                table: "Keyword",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentPortalId",
                schema: "dbo",
                table: "Payment",
                column: "PaymentPortalId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PromotionCodeId",
                schema: "dbo",
                table: "Payment",
                column: "PromotionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserSubscriptionId",
                schema: "dbo",
                table: "Payment",
                column: "UserSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionClick_ClickId",
                schema: "dbo",
                table: "SubscriptionClick",
                column: "ClickId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionClick_SubscriptionId",
                schema: "dbo",
                table: "SubscriptionClick",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionFeature_FeatureId",
                schema: "dbo",
                table: "SubscriptionFeature",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionFeature_SubscriptionId",
                schema: "dbo",
                table: "SubscriptionFeature",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PaymentId",
                schema: "dbo",
                table: "Transaction",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscription_SubscriptionId",
                schema: "dbo",
                table: "UserSubscription",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscription_UserId",
                schema: "dbo",
                table: "UserSubscription",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_ApplicationUserId",
                schema: "dbo",
                table: "Wallet",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransaction_TransactionId",
                schema: "dbo",
                table: "WalletTransaction",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransaction_WalletId",
                schema: "dbo",
                table: "WalletTransaction",
                column: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobKeyword",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PanelTutorial",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubscriptionClick",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubscriptionFeature",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WalletTransaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Keyword",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Click",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Feature",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Wallet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserSubscription",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Subscription",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "PictureName",
                schema: "dbo",
                table: "PaymentPortal");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "dbo",
                table: "PaymentPortal",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                schema: "dbo",
                table: "PaymentPortal",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 13, 9, 18, 57, 24, DateTimeKind.Local).AddTicks(2086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 16, 14, 43, 12, 444, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.CreateTable(
                name: "AccountCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IconPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sort = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountLevel",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LevelStyle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    LevelTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminTheme",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttrCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttrCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCategoryId = table.Column<int>(type: "int", nullable: true),
                    AccountLevelId = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    DiscountedPrice = table.Column<double>(type: "float", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDay = table.Column<int>(type: "int", nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsRecommended = table.Column<bool>(type: "bit", nullable: false),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SalesCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AccountCategory_AccountCategoryId",
                        column: x => x.AccountCategoryId,
                        principalSchema: "dbo",
                        principalTable: "AccountCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Account_AccountLevel_AccountLevelId",
                        column: x => x.AccountLevelId,
                        principalSchema: "dbo",
                        principalTable: "AccountLevel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attr",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttrCategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AttrType = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Filter = table.Column<bool>(type: "bit", nullable: false),
                    IconHtmlCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShowInPage = table.Column<bool>(type: "bit", nullable: false),
                    Sort = table.Column<short>(type: "smallint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attr_AttrCategory_AttrCategoryId",
                        column: x => x.AttrCategoryId,
                        principalSchema: "dbo",
                        principalTable: "AttrCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attr_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttrAccount",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttrCategoryId = table.Column<int>(type: "int", nullable: false),
                    AttrType = table.Column<int>(type: "int", nullable: false),
                    IconHtmlCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<short>(type: "smallint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttrAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttrAccount_AttrCategory_AttrCategoryId",
                        column: x => x.AttrCategoryId,
                        principalSchema: "dbo",
                        principalTable: "AttrCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentPortalId = table.Column<int>(type: "int", nullable: true),
                    PromotionCodeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CookieValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDay = table.Column<int>(type: "int", nullable: false),
                    IsActiveAccount = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_PaymentPortal_PaymentPortalId",
                        column: x => x.PaymentPortalId,
                        principalSchema: "dbo",
                        principalTable: "PaymentPortal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_PromotionCode_PromotionCodeId",
                        column: x => x.PromotionCodeId,
                        principalSchema: "dbo",
                        principalTable: "PromotionCode",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttrValue",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttrId = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttrValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttrValue_Attr_AttrId",
                        column: x => x.AttrId,
                        principalSchema: "dbo",
                        principalTable: "Attr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttrAccountValue",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttrAccountId = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttrAccountValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttrAccountValue_AttrAccount_AttrAccountId",
                        column: x => x.AttrAccountId,
                        principalSchema: "dbo",
                        principalTable: "AttrAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobBranchAttr",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttrId = table.Column<int>(type: "int", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBranchAttr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobBranchAttr_AttrValue_ValueId",
                        column: x => x.ValueId,
                        principalSchema: "dbo",
                        principalTable: "AttrValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobBranchAttr_Attr_AttrId",
                        column: x => x.AttrId,
                        principalSchema: "dbo",
                        principalTable: "Attr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobBranchAttr_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountAttr",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    AttrId = table.Column<int>(type: "int", nullable: false),
                    ValueId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAttr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountAttr_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountAttr_AttrAccountValue_ValueId",
                        column: x => x.ValueId,
                        principalSchema: "dbo",
                        principalTable: "AttrAccountValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountAttr_AttrAccount_AttrId",
                        column: x => x.AttrId,
                        principalSchema: "dbo",
                        principalTable: "AttrAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "05446344-f9cc-4566-bd2c-36791b4e28ed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f0b8766e-17f9-471e-8b7d-769a3ce427d3", "AQAAAAIAAYagAAAAEKgGuSvO2BaE18x1gYIkn+dtabfpx9rSUv71MrUVDc84mZRA0swnK18hLTX66VS2xA==", new DateTime(2025, 4, 13, 9, 18, 57, 39, DateTimeKind.Local).AddTicks(3255), "67d69f8c-a83c-44aa-8b13-f902ffe4c6d8" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "8009d613-9419-4e84-af3a-765a8ab9815f", "AQAAAAIAAYagAAAAECFMY04BE8jUqkmJ7HO4Ia7fDtJk04F9gQYr8SZpp2grhXCFs5J/OzGESDzK5Sr8Zw==", new DateTime(2025, 4, 13, 9, 18, 57, 85, DateTimeKind.Local).AddTicks(9455), "db36bd9a-a30b-4bf2-b0b2-90ea10e46879" });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountCategoryId",
                schema: "dbo",
                table: "Account",
                column: "AccountCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountLevelId",
                schema: "dbo",
                table: "Account",
                column: "AccountLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAttr_AccountId",
                schema: "dbo",
                table: "AccountAttr",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAttr_AttrId",
                schema: "dbo",
                table: "AccountAttr",
                column: "AttrId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAttr_ValueId",
                schema: "dbo",
                table: "AccountAttr",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Attr_AttrCategoryId",
                schema: "dbo",
                table: "Attr",
                column: "AttrCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Attr_CategoryId",
                schema: "dbo",
                table: "Attr",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AttrAccount_AttrCategoryId",
                schema: "dbo",
                table: "AttrAccount",
                column: "AttrCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AttrAccountValue_AttrAccountId",
                schema: "dbo",
                table: "AttrAccountValue",
                column: "AttrAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AttrValue_AttrId",
                schema: "dbo",
                table: "AttrValue",
                column: "AttrId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchAttr_AttrId",
                schema: "dbo",
                table: "JobBranchAttr",
                column: "AttrId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchAttr_JobBranchId",
                schema: "dbo",
                table: "JobBranchAttr",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchAttr_ValueId",
                schema: "dbo",
                table: "JobBranchAttr",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AccountId",
                schema: "dbo",
                table: "Order",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_JobBranchId",
                schema: "dbo",
                table: "Order",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentPortalId",
                schema: "dbo",
                table: "Order",
                column: "PaymentPortalId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PromotionCodeId",
                schema: "dbo",
                table: "Order",
                column: "PromotionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                schema: "dbo",
                table: "Order",
                column: "UserId");
        }
    }
}
