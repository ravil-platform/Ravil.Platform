using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initRavilApiVersion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "Schema");

            migrationBuilder.CreateTable(
                name: "AccountCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Sort = table.Column<short>(type: "smallint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    LevelTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    LevelStyle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionHistories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AddressIp = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminTheme",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttrCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Sort = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttrCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Route = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    TitleListContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadingTime = table.Column<short>(type: "smallint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false),
                    LargePicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SmallPicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsResizePicture = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IndexMeta = table.Column<bool>(type: "bit", nullable: false),
                    CanonicalMeta = table.Column<bool>(type: "bit", nullable: false),
                    MetaCanonicalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    AlternateTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Route = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    NodeLevel = table.Column<short>(type: "smallint", nullable: false),
                    HeadingTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsLastNode = table.Column<bool>(type: "bit", nullable: false),
                    HasAttribute = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IconPicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsResizePicture = table.Column<bool>(type: "bit", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    PageContent = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IndexMeta = table.Column<bool>(type: "bit", nullable: false),
                    CanonicalMeta = table.Column<bool>(type: "bit", nullable: false),
                    MetaCanonicalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Config",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoundingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrenciesAccepted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAccepted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteAlternateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    OrderNotificationPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telegram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Google = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Whatsapp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationPatternCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordPatternCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmsCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmsUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmsPass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailSmtpDomain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentDeliveryNetwork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportBoxTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportBoxDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeSummery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeMetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeActiveSliderCategoryId = table.Column<int>(type: "int", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactMetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogMetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsMetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricingTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricingMetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricingPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricingIconPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricingContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricingAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeAddTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeAddMetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeAddPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeAddIconPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeAddContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentRules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    FreeShippingLimit = table.Column<double>(type: "float", nullable: false),
                    ShippingPrice = table.Column<double>(type: "float", nullable: false),
                    ShippingTimeRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZarinpalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZarinpalMode = table.Column<bool>(type: "bit", nullable: false),
                    ZarinpalMerchant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMultipleCreate = table.Column<bool>(type: "bit", nullable: false),
                    SendNotificationState = table.Column<int>(type: "int", nullable: false),
                    FaqTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaqMetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaqPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaqContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileSupportButtonIsShow = table.Column<bool>(type: "bit", nullable: false),
                    UseSliderOrVideoInHome = table.Column<bool>(type: "bit", nullable: false),
                    DefaultFaqCategory = table.Column<int>(type: "int", nullable: true),
                    ActiveBaseCityId = table.Column<int>(type: "int", nullable: true),
                    HomeMainPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeMainExtFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIndexSeoPages = table.Column<bool>(type: "bit", nullable: false),
                    RedirectSeoPages = table.Column<bool>(type: "bit", nullable: false),
                    CategoriesHeadingTitlePattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriesMetaTitlePattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriesBrandNameMetaDescriptionPattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriesPersonalBrandMetaDescriptionPattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobsBrandNameMetaTitlePattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobsPersonalBrandMetaTitlePattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobsBrandNameMetaDescriptionPattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobsPersonalBrandMetaDescriptionPattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalLoginState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusAnswer = table.Column<bool>(type: "bit", nullable: false),
                    IsReadByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    AnswerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayOfWeek",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlternateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersianName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    IsSelectedPersianName = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfWeek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaqCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackSlider",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackSlider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobBranchAds",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobBranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Pinned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBranchAds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobBranchRelatedJob",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentCityId = table.Column<int>(type: "int", nullable: false),
                    CurrentCityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayedCityId = table.Column<int>(type: "int", nullable: false),
                    DisplayedCityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBranchRelatedJob", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Long = table.Column<double>(type: "float", nullable: false),
                    PlaceType = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentPortal",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPortal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionCode",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CartMinimum = table.Column<double>(type: "float", nullable: true),
                    CartMaximum = table.Column<double>(type: "float", nullable: true),
                    UseCountLimit = table.Column<short>(type: "smallint", nullable: true),
                    IsUseLimit = table.Column<bool>(type: "bit", nullable: false),
                    IsActiveForDiscounts = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RedirectionUrl",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RedirectionType = table.Column<int>(type: "int", nullable: false),
                    LatestUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedirectionUrl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    ServiceSummary = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    ServicePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShortLink",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortKey = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateBase",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    UniqueName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IconHtmlCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Target",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationCategoryId = table.Column<int>(type: "int", nullable: false),
                    DestinationCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginCategoryId = table.Column<int>(type: "int", nullable: false),
                    OriginCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Target", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HoverPic = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telegram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsApp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFile",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersToken",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashJwtToken = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    HashRefreshToken = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    TokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshTokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Device = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    DiscountedPrice = table.Column<double>(type: "float", nullable: false),
                    SalesCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsRecommended = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDay = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountLevelId = table.Column<int>(type: "int", nullable: true),
                    AccountCategoryId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
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
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    AttrType = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<short>(type: "smallint", nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconHtmlCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttrCategoryId = table.Column<int>(type: "int", nullable: false)
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
                name: "BlogCategoryRel",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategoryRel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogCategoryRel_BlogCategory_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalSchema: "dbo",
                        principalTable: "BlogCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCategoryRel_Blog_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "dbo",
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Route = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false),
                    LargePicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SmallPicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebSiteName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    PhoneNumberInfos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaInfos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowPhoneTelInSite = table.Column<bool>(type: "bit", nullable: true),
                    ShowFirstPhoneMobileInSite = table.Column<bool>(type: "bit", nullable: true),
                    IsResizePicture = table.Column<bool>(type: "bit", nullable: false),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewCountTotal = table.Column<int>(type: "int", nullable: false),
                    AverageRate = table.Column<int>(type: "int", nullable: false),
                    IsGoogleData = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectedReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobBrandId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Brand_JobBrandId",
                        column: x => x.JobBrandId,
                        principalSchema: "dbo",
                        principalTable: "Brand",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attr",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    AttrType = table.Column<int>(type: "int", nullable: false),
                    Filter = table.Column<bool>(type: "bit", nullable: false),
                    ShowInPage = table.Column<bool>(type: "bit", nullable: false),
                    Sort = table.Column<short>(type: "smallint", nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconHtmlCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttrCategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "Faq",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faq_FaqCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "FaqCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryService",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "CityBase",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityBase_StateBase_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "StateBase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subtitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsResizePicture = table.Column<bool>(type: "bit", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false),
                    StateBaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IndexMeta = table.Column<bool>(type: "bit", nullable: false),
                    CanonicalMeta = table.Column<bool>(type: "bit", nullable: false),
                    MetaCanonicalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_StateBase_StateBaseId",
                        column: x => x.StateBaseId,
                        principalSchema: "dbo",
                        principalTable: "StateBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogTag",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogTag_Blog_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "dbo",
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "dbo",
                        principalTable: "Tag",
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
                    Value = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    AttrAccountId = table.Column<int>(type: "int", nullable: false)
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
                name: "JobCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCategory_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "dbo",
                        principalTable: "Job",
                        principalColumn: "Id",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttrValue",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    AttrId = table.Column<int>(type: "int", nullable: false)
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
                name: "FaqJobCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaqId = table.Column<int>(type: "int", nullable: false),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqJobCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaqJobCategory_Category_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaqJobCategory_Faq_FaqId",
                        column: x => x.FaqId,
                        principalSchema: "dbo",
                        principalTable: "Faq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subtitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Route = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsResizePicture = table.Column<bool>(type: "bit", nullable: false),
                    CityBaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IndexMeta = table.Column<bool>(type: "bit", nullable: false),
                    CanonicalMeta = table.Column<bool>(type: "bit", nullable: false),
                    MetaCanonicalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_CityBase_CityBaseId",
                        column: x => x.CityBaseId,
                        principalSchema: "dbo",
                        principalTable: "CityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    LockoutReason = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    OneTimeUseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserIsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    ExpireTimeSpanBlock = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDateReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OneTimeUseCodeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlockedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserNameType = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    StateBaseId = table.Column<int>(type: "int", nullable: true),
                    CityBaseId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    Email = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_CityBase_CityBaseId",
                        column: x => x.CityBaseId,
                        principalSchema: "dbo",
                        principalTable: "CityBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUser_StateBase_StateBaseId",
                        column: x => x.StateBaseId,
                        principalSchema: "dbo",
                        principalTable: "StateBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUser_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "State",
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "CityCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityCategory_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobBranch",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    HeadingTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    BranchContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchVideo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LargePicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SmallPicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsConfirmedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    AverageRate = table.Column<int>(type: "int", nullable: false),
                    AdminName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOffer = table.Column<bool>(type: "bit", nullable: false),
                    IsAdminCreator = table.Column<bool>(type: "bit", nullable: false),
                    IsResizePicture = table.Column<bool>(type: "bit", nullable: false),
                    JobTimeWorkType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectedReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IndexMeta = table.Column<bool>(type: "bit", nullable: false),
                    CanonicalMeta = table.Column<bool>(type: "bit", nullable: false),
                    MetaCanonicalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobBranch_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobBranch_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "dbo",
                        principalTable: "Job",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StateBaseId = table.Column<int>(type: "int", nullable: false),
                    CityBaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddresses_CityBase_CityBaseId",
                        column: x => x.CityBaseId,
                        principalSchema: "dbo",
                        principalTable: "CityBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddresses_StateBase_StateBaseId",
                        column: x => x.StateBaseId,
                        principalSchema: "dbo",
                        principalTable: "StateBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBlogLike",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikeTimeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBlogLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBlogLike_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBlogLike_Blog_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "dbo",
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    OtherAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Neighbourhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 12, 31, 10, 50, 14, 549, DateTimeKind.Local).AddTicks(7463)),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_CityBase_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "CityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "dbo",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_StateBase_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "StateBase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Banner",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    ExpireDay = table.Column<int>(type: "int", nullable: true),
                    LargePicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SmallPicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    LinkPage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerType = table.Column<int>(type: "int", nullable: false),
                    BannerPictureType = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banner_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentType = table.Column<int>(type: "int", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserIp = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Blog_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "dbo",
                        principalTable: "Blog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobBranchAttr",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AttrId = table.Column<int>(type: "int", nullable: false),
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
                name: "JobBranchGallery",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Sort = table.Column<byte>(type: "tinyint", maxLength: 150, nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBranchGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobBranchGallery_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobBranchShortLink",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBranchShortLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobBranchShortLink_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
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
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobBranchTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "dbo",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSelectionSlider",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobSliderType = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSelectionSlider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSelectionSlider_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobService",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobService_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "dbo",
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTimeWork",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DayOfWeekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTimeWork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTimeWork_DayOfWeek_DayOfWeekId",
                        column: x => x.DayOfWeekId,
                        principalSchema: "Schema",
                        principalTable: "DayOfWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTimeWork_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainSlider",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDay = table.Column<int>(type: "int", nullable: true),
                    LargePicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SmallPicture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LinkPage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSlider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainSlider_CityBase_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "CityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainSlider_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainSlider_StateBase_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "StateBase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    PaymentAmount = table.Column<double>(type: "float", nullable: false),
                    ExpireDay = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsActiveAccount = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CookieValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentPortalId = table.Column<int>(type: "int", nullable: true),
                    PromotionCodeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "UserBookMark",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserBookMarkType = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: true),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookMark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBookMark_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookMark_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersFeedbackSlider",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFeedbackSlider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersFeedbackSlider_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBannerClick",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BannerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBannerClick", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBannerClick_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBannerClick_Banner_BannerId",
                        column: x => x.BannerId,
                        principalSchema: "dbo",
                        principalTable: "Banner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBannerView",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBannerView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBannerView_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationUser",
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

            migrationBuilder.CreateTable(
                name: "AnswerComment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdminAnswer = table.Column<bool>(type: "bit", nullable: false),
                    UserIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerCommentTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    AnswerCommentText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AnswerCommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerComment_Comment_CommentId",
                        column: x => x.CommentId,
                        principalSchema: "dbo",
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ApplicationUser",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "BirthDate", "BlockedDate", "CityBaseId", "ConcurrencyStamp", "ConfirmationDate", "Email", "EmailConfirmed", "ExpireTimeSpanBlock", "Firstname", "Gender", "IsDeleted", "LastDeleteBicycleDate", "LastUpdateDateReason", "Lastname", "LockoutEnabled", "LockoutEnd", "LockoutReason", "NationalCode", "NormalizedEmail", "NormalizedUserName", "OneTimeUseCode", "OneTimeUseCodeEnd", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "RegisterDate", "SecurityStamp", "StateBaseId", "StateId", "TwoFactorEnabled", "UpdateDate", "UserIsBlocked", "UserName", "UserNameType" },
                values: new object[,]
                {
                    { "05446344-f9cc-4566-bd2c-36791b4e28ed", 0, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "6c15e7d6-ba1a-4624-aa4b-edda95dc3c59", null, "admin@localhost.com", true, 0, "Admin", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "System", false, null, null, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", null, null, "AQAAAAIAAYagAAAAEDKVQjyRYH9bSKIKg7cMzaeQTUhU+ocRiKKvV5SSNSput7pYm2NyzfvlrVsDD1u2EA==", null, null, false, new DateTime(2024, 12, 31, 10, 50, 14, 563, DateTimeKind.Local).AddTicks(2978), "15397fe1-2db8-4649-85b8-0a1640c278db", null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@localhost.com", 0 },
                    { "2ec9f480-7288-4d0f-a1cd-53cc89968b45", 0, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "4375431c-fd84-4c51-acfc-fab6f9d5728d", null, "user@localhost.com", true, 0, "System", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", false, null, null, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", null, null, "AQAAAAIAAYagAAAAEB7ZQxjpa05Z+wJLjvknLnHn/VwRnSpwicg+G6XzYw8OD1uoSjBzmLigQvpwK+2yOw==", null, null, false, new DateTime(2024, 12, 31, 10, 50, 14, 613, DateTimeKind.Local).AddTicks(6550), "82d7c5f9-0696-47eb-ac1e-9560cfec0ece", null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user@localhost.com", 0 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9845f909-799c-45fd-9158-58c1336ffddc", null, "User", "USER" },
                    { "cb275765-1cac-4652-a03f-f8871dd575d1", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Config",
                columns: new[] { "Id", "AboutUsContent", "AboutUsMetaDesc", "AboutUsTitle", "AboutUsVideo", "ActiveBaseCityId", "Address", "BlogMetaDesc", "BlogTitle", "CategoriesBrandNameMetaDescriptionPattern", "CategoriesHeadingTitlePattern", "CategoriesMetaTitlePattern", "CategoriesPersonalBrandMetaDescriptionPattern", "CommentRules", "ConfirmationPatternCode", "ContactContent", "ContactMetaDesc", "ContactTitle", "ContentDeliveryNetwork", "CurrenciesAccepted", "DefaultFaqCategory", "Domain", "Email", "ExternalLoginState", "Facebook", "FaqContent", "FaqMetaDesc", "FaqPicture", "FaqTitle", "FooterText", "FoundingDate", "FreeAddContent", "FreeAddIconPicture", "FreeAddMetaDesc", "FreeAddPicture", "FreeAddTitle", "FreeShippingLimit", "Google", "HomeActiveSliderCategoryId", "HomeDescription", "HomeMainExtFileName", "HomeMainPicture", "HomeMetaDesc", "HomeSummery", "HomeTitle", "Instagram", "IsMultipleCreate", "JobsBrandNameMetaDescriptionPattern", "JobsBrandNameMetaTitlePattern", "JobsPersonalBrandMetaDescriptionPattern", "JobsPersonalBrandMetaTitlePattern", "MailDisplayName", "MailPassword", "MailSmtpDomain", "MailUserName", "MapUrl", "Mobile", "MobileSupportButtonIsShow", "NoIndexSeoPages", "OrderNotificationPhoneNumber", "OrderNumber", "PaymentAccepted", "PriceRange", "PricingAccountDescription", "PricingContent", "PricingIconPicture", "PricingMetaDesc", "PricingPicture", "PricingTitle", "RedirectSeoPages", "ResetPasswordPatternCode", "SendNotificationState", "ShippingPrice", "ShippingTimeRange", "SiteAlternateName", "SiteName", "SmsCenter", "SmsPass", "SmsUser", "SupportBoxDesc", "SupportBoxTitle", "Tel", "Telegram", "Twitter", "UseSliderOrVideoInHome", "Whatsapp", "ZarinpalMerchant", "ZarinpalMode", "ZarinpalUrl" },
                values: new object[] { 1, null, null, null, null, 245, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "https://localhost:5001", null, 1, null, null, null, null, null, null, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, 200000.0, null, 1, null, null, null, null, null, null, null, false, null, null, null, null, null, null, null, null, null, null, false, false, null, 10000, null, null, null, null, null, null, null, null, false, null, 0, 25000.0, null, "ravil", "راویل", null, null, null, null, null, null, null, null, false, null, null, false, null });

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
                name: "IX_Address_CityId",
                schema: "dbo",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_JobBranchId",
                schema: "dbo",
                table: "Address",
                column: "JobBranchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                schema: "dbo",
                table: "Address",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                schema: "dbo",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerComment_CommentId",
                schema: "dbo",
                table: "AnswerComment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "ApplicationUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_CityBaseId",
                schema: "dbo",
                table: "ApplicationUser",
                column: "CityBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_StateBaseId",
                schema: "dbo",
                table: "ApplicationUser",
                column: "StateBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_StateId",
                schema: "dbo",
                table: "ApplicationUser",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "ApplicationUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

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
                name: "IX_Banner_JobBranchId",
                schema: "dbo",
                table: "Banner",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategoryRel_BlogCategoryId",
                schema: "dbo",
                table: "BlogCategoryRel",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategoryRel_BlogId",
                schema: "dbo",
                table: "BlogCategoryRel",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_BlogId",
                schema: "dbo",
                table: "BlogTag",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_TagId",
                schema: "dbo",
                table: "BlogTag",
                column: "TagId");

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
                name: "IX_City_CityBaseId",
                schema: "dbo",
                table: "City",
                column: "CityBaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CityBase_StateId",
                schema: "dbo",
                table: "CityBase",
                column: "StateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CityCategory_CategoryId",
                schema: "dbo",
                table: "CityCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CityCategory_CityId",
                schema: "dbo",
                table: "CityCategory",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BlogId",
                schema: "dbo",
                table: "Comment",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_JobBranchId",
                schema: "dbo",
                table: "Comment",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                schema: "dbo",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_CategoryId",
                schema: "dbo",
                table: "Faq",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FaqJobCategory_FaqId",
                schema: "dbo",
                table: "FaqJobCategory",
                column: "FaqId");

            migrationBuilder.CreateIndex(
                name: "IX_FaqJobCategory_JobCategoryId",
                schema: "dbo",
                table: "FaqJobCategory",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobBrandId",
                schema: "dbo",
                table: "Job",
                column: "JobBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranch_JobId",
                schema: "dbo",
                table: "JobBranch",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranch_UserId",
                schema: "dbo",
                table: "JobBranch",
                column: "UserId");

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
                name: "IX_JobBranchGallery_JobBranchId",
                schema: "dbo",
                table: "JobBranchGallery",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchShortLink_JobBranchId",
                schema: "dbo",
                table: "JobBranchShortLink",
                column: "JobBranchId");

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
                name: "IX_JobCategory_CategoryId",
                schema: "dbo",
                table: "JobCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCategory_JobId",
                schema: "dbo",
                table: "JobCategory",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSelectionSlider_JobBranchId",
                schema: "dbo",
                table: "JobSelectionSlider",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JobService_JobBranchId",
                schema: "dbo",
                table: "JobService",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JobService_ServiceId",
                schema: "dbo",
                table: "JobService",
                column: "ServiceId");

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

            migrationBuilder.CreateIndex(
                name: "IX_JobTimeWork_DayOfWeekId",
                schema: "dbo",
                table: "JobTimeWork",
                column: "DayOfWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTimeWork_JobBranchId",
                schema: "dbo",
                table: "JobTimeWork",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MainSlider_CityId",
                schema: "dbo",
                table: "MainSlider",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_MainSlider_JobBranchId",
                schema: "dbo",
                table: "MainSlider",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MainSlider_StateId",
                schema: "dbo",
                table: "MainSlider",
                column: "StateId");

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

            migrationBuilder.CreateIndex(
                name: "IX_State_StateBaseId",
                schema: "dbo",
                table: "State",
                column: "StateBaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_CityBaseId",
                schema: "dbo",
                table: "UserAddresses",
                column: "CityBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_StateBaseId",
                schema: "dbo",
                table: "UserAddresses",
                column: "StateBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                schema: "dbo",
                table: "UserAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBannerClick_BannerId",
                schema: "dbo",
                table: "UserBannerClick",
                column: "BannerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBannerClick_UserId",
                schema: "dbo",
                table: "UserBannerClick",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserBlogLike_BlogId",
                schema: "dbo",
                table: "UserBlogLike",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBlogLike_UserId",
                schema: "dbo",
                table: "UserBlogLike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookMark_JobBranchId",
                schema: "dbo",
                table: "UserBookMark",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookMark_UserId",
                schema: "dbo",
                table: "UserBookMark",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFeedbackSlider_JobBranchId",
                schema: "dbo",
                table: "UsersFeedbackSlider",
                column: "JobBranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAttr",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ActionHistories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdminTheme",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AnswerComment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BlogCategoryRel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BlogTag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CategoryService",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CityCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Config",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactUs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FaqJobCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FeedbackSlider",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobBranchAds",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobBranchAttr",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobBranchGallery",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobBranchRelatedJob",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobBranchShortLink",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobBranchTag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobSelectionSlider",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobService",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobTag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobTimeWork",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MainSlider",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RedirectionUrl",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShortLink",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Target",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UploadedFile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddresses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserBannerClick",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserBannerView",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserBlogLike",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserBookMark",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UsersFeedbackSlider",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UsersToken",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttrAccountValue",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Comment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BlogCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "City",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Faq",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttrValue",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Service",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DayOfWeek",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentPortal",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PromotionCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Banner",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttrAccount",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Blog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FaqCategory",
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
                name: "JobBranch",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttrCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CityBase",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "State",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StateBase",
                schema: "dbo");
        }
    }
}
