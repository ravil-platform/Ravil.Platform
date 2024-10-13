using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addHistoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StateBase_StateId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "dbo",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "dbo",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "dbo",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "dbo",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AttrAccount_AttrCategory_AttrCategoryId",
                schema: "dbo",
                table: "AttrAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Banner_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_CityBase_StateBase_StateBaseId",
                schema: "dbo",
                table: "CityBase");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                schema: "dbo",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_JobBranch_AspNetUsers_UserOwnerId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_JobBranchAttr_JobBranch_BranchId",
                schema: "dbo",
                table: "JobBranchAttr");

            migrationBuilder.DropForeignKey(
                name: "FK_JobBranchTag_JobBranch_JobBranchId",
                schema: "dbo",
                table: "JobBranchTag");

            migrationBuilder.DropForeignKey(
                name: "FK_MainSlider_JobBranch_JobBranchId",
                schema: "dbo",
                table: "MainSlider");

            migrationBuilder.DropForeignKey(
                name: "FK_MainSlider_StateBase_StateId",
                schema: "dbo",
                table: "MainSlider");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                schema: "dbo",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBannerClick_AspNetUsers_UserId",
                schema: "dbo",
                table: "UserBannerClick");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBannerView_AspNetUsers_UserId",
                schema: "dbo",
                table: "UserBannerView");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBlogLike_AspNetUsers_UserId",
                schema: "dbo",
                table: "UserBlogLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBookMark_AspNetUsers_UserId",
                schema: "dbo",
                table: "UserBookMark");

            migrationBuilder.DropTable(
                name: "Answer",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "Article",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "BrandOwner",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "BreadCrumb",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "Complaint",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DayOfWeeks",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "Faqs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GeoLocation",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "ReviewItem",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "UploadedFiles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddress",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserBlogAction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserJobAction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLikedGallery",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WalletTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "TimeClose",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "TimeOpens",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Wallets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TimeWorks",
                schema: "Schema");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_JobBranchAttr_BranchId",
                schema: "dbo",
                table: "JobBranchAttr");

            migrationBuilder.DropIndex(
                name: "IX_JobBranch_UserOwnerId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DeleteData(
                schema: "Schema",
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Schema",
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Schema",
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Schema",
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Schema",
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Schema",
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Schema",
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "dbo",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "dbo",
                table: "JobBranchAttr");

            migrationBuilder.DropColumn(
                name: "UserOwnerId",
                schema: "dbo",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "dbo",
                table: "Blog");

            migrationBuilder.EnsureSchema(
                name: "Accounts");

            migrationBuilder.EnsureSchema(
                name: "ActionHistories");

            migrationBuilder.EnsureSchema(
                name: "Addresses");

            migrationBuilder.EnsureSchema(
                name: "AdminThemes");

            migrationBuilder.EnsureSchema(
                name: "Comments");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.EnsureSchema(
                name: "Attrs");

            migrationBuilder.EnsureSchema(
                name: "Banners");

            migrationBuilder.EnsureSchema(
                name: "Blogs");

            migrationBuilder.EnsureSchema(
                name: "Brands");

            migrationBuilder.EnsureSchema(
                name: "Categories");

            migrationBuilder.EnsureSchema(
                name: "Cities");

            migrationBuilder.EnsureSchema(
                name: "Configs");

            migrationBuilder.EnsureSchema(
                name: "ContactUs");

            migrationBuilder.EnsureSchema(
                name: "Faqs");

            migrationBuilder.EnsureSchema(
                name: "FeedbackSliders");

            migrationBuilder.EnsureSchema(
                name: "Jobs");

            migrationBuilder.EnsureSchema(
                name: "Locations");

            migrationBuilder.EnsureSchema(
                name: "MainSliders");

            migrationBuilder.EnsureSchema(
                name: "Orders");

            migrationBuilder.EnsureSchema(
                name: "PaymentPortals");

            migrationBuilder.EnsureSchema(
                name: "RedirectionUrls");

            migrationBuilder.EnsureSchema(
                name: "Services");

            migrationBuilder.EnsureSchema(
                name: "ShortLinks");

            migrationBuilder.EnsureSchema(
                name: "States");

            migrationBuilder.EnsureSchema(
                name: "Tags");

            migrationBuilder.EnsureSchema(
                name: "Teams");

            migrationBuilder.EnsureSchema(
                name: "UploadedFiles");

            migrationBuilder.RenameTable(
                name: "UsersFeedbackSlider",
                schema: "dbo",
                newName: "UsersFeedbackSlider");

            migrationBuilder.RenameTable(
                name: "UserBookMark",
                schema: "dbo",
                newName: "UserBookMark",
                newSchema: "Users");

            migrationBuilder.RenameTable(
                name: "UserBlogLike",
                schema: "dbo",
                newName: "UserBlogLike",
                newSchema: "Users");

            migrationBuilder.RenameTable(
                name: "UserBannerView",
                schema: "dbo",
                newName: "UserBannerView",
                newSchema: "Users");

            migrationBuilder.RenameTable(
                name: "UserBannerClick",
                schema: "dbo",
                newName: "UserBannerClick",
                newSchema: "Users");

            migrationBuilder.RenameTable(
                name: "Team",
                schema: "dbo",
                newName: "Team",
                newSchema: "Teams");

            migrationBuilder.RenameTable(
                name: "Tag",
                schema: "dbo",
                newName: "Tag",
                newSchema: "Tags");

            migrationBuilder.RenameTable(
                name: "StateBase",
                schema: "dbo",
                newName: "StateBase",
                newSchema: "States");

            migrationBuilder.RenameTable(
                name: "State",
                schema: "dbo",
                newName: "State",
                newSchema: "States");

            migrationBuilder.RenameTable(
                name: "ShortLink",
                schema: "dbo",
                newName: "ShortLink",
                newSchema: "ShortLinks");

            migrationBuilder.RenameTable(
                name: "Service",
                schema: "dbo",
                newName: "Service",
                newSchema: "Services");

            migrationBuilder.RenameTable(
                name: "RedirectionUrl",
                schema: "dbo",
                newName: "RedirectionUrl",
                newSchema: "RedirectionUrls");

            migrationBuilder.RenameTable(
                name: "PromotionCode",
                schema: "dbo",
                newName: "PromotionCode",
                newSchema: "Orders");

            migrationBuilder.RenameTable(
                name: "PaymentPortal",
                schema: "dbo",
                newName: "PaymentPortal",
                newSchema: "PaymentPortals");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "dbo",
                newName: "Order",
                newSchema: "Orders");

            migrationBuilder.RenameTable(
                name: "MainSlider",
                schema: "dbo",
                newName: "MainSlider",
                newSchema: "MainSliders");

            migrationBuilder.RenameTable(
                name: "Location",
                schema: "dbo",
                newName: "Location",
                newSchema: "Locations");

            migrationBuilder.RenameTable(
                name: "JobTimeWork",
                schema: "dbo",
                newName: "JobTimeWork",
                newSchema: "Jobs");

            migrationBuilder.RenameTable(
                name: "JobTag",
                schema: "dbo",
                newName: "JobTag",
                newSchema: "Jobs");

            migrationBuilder.RenameTable(
                name: "JobService",
                schema: "dbo",
                newName: "JobService",
                newSchema: "Jobs");

            migrationBuilder.RenameTable(
                name: "JobSelectionSlider",
                schema: "dbo",
                newName: "JobSelectionSlider",
                newSchema: "Jobs");

            migrationBuilder.RenameTable(
                name: "JobCategory",
                schema: "dbo",
                newName: "JobCategory");

            migrationBuilder.RenameTable(
                name: "JobBranchTag",
                schema: "dbo",
                newName: "JobBranchTag",
                newSchema: "Jobs");

            migrationBuilder.RenameTable(
                name: "JobBranchShortLink",
                schema: "dbo",
                newName: "JobBranchShortLink",
                newSchema: "Jobs");

            migrationBuilder.RenameTable(
                name: "JobBranchGallery",
                schema: "dbo",
                newName: "JobBranchGallery",
                newSchema: "Jobs");

            migrationBuilder.RenameTable(
                name: "JobBranchAttr",
                schema: "dbo",
                newName: "JobBranchAttr",
                newSchema: "Jobs");

            migrationBuilder.RenameTable(
                name: "JobBranch",
                schema: "dbo",
                newName: "JobBranch",
                newSchema: "Jobs");

            migrationBuilder.RenameTable(
                name: "Job",
                schema: "dbo",
                newName: "Job",
                newSchema: "Jobs");

            migrationBuilder.RenameTable(
                name: "FeedbackSlider",
                schema: "dbo",
                newName: "FeedbackSlider",
                newSchema: "FeedbackSliders");

            migrationBuilder.RenameTable(
                name: "FaqCategory",
                schema: "dbo",
                newName: "FaqCategory",
                newSchema: "Faqs");

            migrationBuilder.RenameTable(
                name: "ContactUs",
                schema: "dbo",
                newName: "ContactUs",
                newSchema: "ContactUs");

            migrationBuilder.RenameTable(
                name: "Config",
                schema: "dbo",
                newName: "Config",
                newSchema: "Configs");

            migrationBuilder.RenameTable(
                name: "Comment",
                schema: "dbo",
                newName: "Comment",
                newSchema: "Comments");

            migrationBuilder.RenameTable(
                name: "CityCategory",
                schema: "dbo",
                newName: "CityCategory",
                newSchema: "Cities");

            migrationBuilder.RenameTable(
                name: "CityBase",
                schema: "dbo",
                newName: "CityBase",
                newSchema: "Cities");

            migrationBuilder.RenameTable(
                name: "City",
                schema: "dbo",
                newName: "City",
                newSchema: "Cities");

            migrationBuilder.RenameTable(
                name: "CategoryService",
                schema: "dbo",
                newName: "CategoryService",
                newSchema: "Categories");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "dbo",
                newName: "Category",
                newSchema: "Categories");

            migrationBuilder.RenameTable(
                name: "Brand",
                schema: "dbo",
                newName: "Brand",
                newSchema: "Brands");

            migrationBuilder.RenameTable(
                name: "BlogTag",
                schema: "dbo",
                newName: "BlogTag",
                newSchema: "Blogs");

            migrationBuilder.RenameTable(
                name: "BlogCategoryRel",
                schema: "dbo",
                newName: "BlogCategoryRel",
                newSchema: "Blogs");

            migrationBuilder.RenameTable(
                name: "BlogCategory",
                schema: "dbo",
                newName: "BlogCategory",
                newSchema: "Blogs");

            migrationBuilder.RenameTable(
                name: "Blog",
                schema: "dbo",
                newName: "Blog",
                newSchema: "Blogs");

            migrationBuilder.RenameTable(
                name: "Banner",
                schema: "dbo",
                newName: "Banner",
                newSchema: "Banners");

            migrationBuilder.RenameTable(
                name: "AttrValue",
                schema: "dbo",
                newName: "AttrValue",
                newSchema: "Attrs");

            migrationBuilder.RenameTable(
                name: "AttrCategory",
                schema: "dbo",
                newName: "AttrCategory",
                newSchema: "Attrs");

            migrationBuilder.RenameTable(
                name: "AttrAccountValue",
                schema: "dbo",
                newName: "AttrAccountValue",
                newSchema: "Attrs");

            migrationBuilder.RenameTable(
                name: "AttrAccount",
                schema: "dbo",
                newName: "AttrAccount",
                newSchema: "Attrs");

            migrationBuilder.RenameTable(
                name: "Attr",
                schema: "dbo",
                newName: "Attr",
                newSchema: "Attrs");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "dbo",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AnswerComment",
                schema: "dbo",
                newName: "AnswerComment",
                newSchema: "Comments");

            migrationBuilder.RenameTable(
                name: "AdminTheme",
                schema: "dbo",
                newName: "AdminTheme",
                newSchema: "AdminThemes");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "dbo",
                newName: "Address",
                newSchema: "Addresses");

            migrationBuilder.RenameTable(
                name: "AccountLevel",
                schema: "dbo",
                newName: "AccountLevel",
                newSchema: "Accounts");

            migrationBuilder.RenameTable(
                name: "AccountCategory",
                schema: "dbo",
                newName: "AccountCategory",
                newSchema: "Accounts");

            migrationBuilder.RenameTable(
                name: "AccountAttr",
                schema: "dbo",
                newName: "AccountAttr",
                newSchema: "Accounts");

            migrationBuilder.RenameTable(
                name: "Account",
                schema: "dbo",
                newName: "Account",
                newSchema: "Accounts");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                schema: "Teams",
                table: "Team",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TagId",
                schema: "Tags",
                table: "Tag",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountLevelId",
                schema: "Accounts",
                table: "AccountLevel",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "PersianName",
                schema: "Schema",
                table: "DayOfWeek",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "AlternateName",
                schema: "Schema",
                table: "DayOfWeek",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "UsersFeedbackSlider",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsApp",
                schema: "Teams",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                schema: "Teams",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                schema: "Teams",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                schema: "Teams",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Teams",
                table: "Team",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Teams",
                table: "Team",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Degree",
                schema: "Teams",
                table: "Team",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "UniqueName",
                schema: "Tags",
                table: "Tag",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Tags",
                table: "Tag",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "Tags",
                table: "Tag",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IconHtmlCode",
                schema: "Tags",
                table: "Tag",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "States",
                table: "StateBase",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Subtitle",
                schema: "States",
                table: "State",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "States",
                table: "State",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                schema: "States",
                table: "State",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDesc",
                schema: "States",
                table: "State",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "States",
                table: "State",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortKey",
                schema: "ShortLinks",
                table: "ShortLink",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceTitle",
                schema: "Services",
                table: "Service",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceSummary",
                schema: "Services",
                table: "Service",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServicePicture",
                schema: "Services",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Orders",
                table: "PromotionCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Orders",
                table: "PromotionCode",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Orders",
                table: "PromotionCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Orders",
                table: "PromotionCode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Orders",
                table: "PromotionCode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Orders",
                table: "PromotionCode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "PaymentPortals",
                table: "PaymentPortal",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "PaymentPortals",
                table: "PaymentPortal",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PaymentAmount",
                schema: "Orders",
                table: "Order",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                schema: "Orders",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                schema: "Orders",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "Orders",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalInfo",
                schema: "Orders",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Orders",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "MainSliders",
                table: "MainSlider",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkPage",
                schema: "MainSliders",
                table: "MainSlider",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "MainSliders",
                table: "MainSlider",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "MainSliders",
                table: "MainSlider",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "MainSliders",
                table: "MainSlider",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "MainSliders",
                table: "MainSlider",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "MainSliders",
                table: "MainSlider",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "MainSliders",
                table: "MainSlider",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "Locations",
                table: "Location",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                schema: "Locations",
                table: "Location",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                schema: "Jobs",
                table: "JobTimeWork",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                schema: "Jobs",
                table: "JobTimeWork",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "Jobs",
                table: "JobBranchTag",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortKey",
                schema: "Jobs",
                table: "JobBranchShortLink",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "JobBranchId",
                schema: "Jobs",
                table: "JobBranchAttr",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "SmallPicture",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDesc",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LargePicture",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeadingTitle",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConfirmationDate",
                schema: "Jobs",
                table: "JobBranch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BranchVideo",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BranchContent",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Jobs",
                table: "JobBranch",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "WebSiteName",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmallPicture",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumberInfos",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LargePicture",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                schema: "Jobs",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserRole",
                schema: "FeedbackSliders",
                table: "FeedbackSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "FeedbackSliders",
                table: "FeedbackSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "FeedbackSliders",
                table: "FeedbackSlider",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "FeedbackSliders",
                table: "FeedbackSlider",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Faqs",
                table: "FaqCategory",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                schema: "ContactUs",
                table: "ContactUs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                schema: "ContactUs",
                table: "ContactUs",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "ContactUs",
                table: "ContactUs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "ContactUs",
                table: "ContactUs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                schema: "ContactUs",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                schema: "ContactUs",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Whatsapp",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupportBoxTitle",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupportBoxDesc",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmsUser",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmsPass",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmsCenter",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteName",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteAlternateName",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShippingTimeRange",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SendNotificationState",
                schema: "Configs",
                table: "Config",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "ResetPasswordPatternCode",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PricingTitle",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PricingPicture",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PricingMetaDesc",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PricingIconPicture",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PriceRange",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentAccepted",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderNotificationPhoneNumber",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MailUserName",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MailSmtpDomain",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MailPassword",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MailDisplayName",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobsPersonalBrandMetaTitlePattern",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobsPersonalBrandMetaDescriptionPattern",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobsBrandNameMetaTitlePattern",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobsBrandNameMetaDescriptionPattern",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeTitle",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeSummery",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeMetaDesc",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeMainPicture",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeMainExtFileName",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HomeActiveSliderCategoryId",
                schema: "Configs",
                table: "Config",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Google",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreeAddTitle",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreeAddPicture",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreeAddMetaDesc",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreeAddIconPicture",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaqTitle",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaqPicture",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaqMetaDesc",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Facebook",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Domain",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrenciesAccepted",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentDeliveryNetwork",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactTitle",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactMetaDesc",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmationPatternCode",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriesPersonalBrandMetaDescriptionPattern",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriesMetaTitlePattern",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriesBrandNameMetaDescriptionPattern",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BlogTitle",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BlogMetaDesc",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutUsVideo",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutUsTitle",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutUsMetaDesc",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoriesHeadingTitlePattern",
                schema: "Configs",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserIp",
                schema: "Comments",
                table: "Comment",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Comments",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Comments",
                table: "Comment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                schema: "Comments",
                table: "Comment",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                schema: "Comments",
                table: "Comment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Cities",
                table: "CityCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Cities",
                table: "CityCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Cities",
                table: "CityCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Cities",
                table: "CityCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Cities",
                table: "CityCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "StateBaseId",
                schema: "Cities",
                table: "CityBase",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Cities",
                table: "CityBase",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Cities",
                table: "CityBase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Cities",
                table: "CityBase",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Cities",
                table: "CityBase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Cities",
                table: "CityBase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Cities",
                table: "CityBase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Subtitle",
                schema: "Cities",
                table: "City",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "Cities",
                table: "City",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "Cities",
                table: "City",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                schema: "Cities",
                table: "City",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDesc",
                schema: "Cities",
                table: "City",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "Cities",
                table: "City",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Categories",
                table: "CategoryService",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Categories",
                table: "CategoryService",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Categories",
                table: "CategoryService",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Categories",
                table: "CategoryService",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Categories",
                table: "CategoryService",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "Categories",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValue: (byte)1);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "Categories",
                table: "Category",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "PageContent",
                schema: "Categories",
                table: "Category",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Categories",
                table: "Category",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                schema: "Categories",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDesc",
                schema: "Categories",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "Categories",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeadingTitle",
                schema: "Categories",
                table: "Category",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Brands",
                table: "Brand",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "AlternateTitle",
                schema: "Brands",
                table: "Brand",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Brands",
                table: "Brand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Brands",
                table: "Brand",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Brands",
                table: "Brand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Brands",
                table: "Brand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Brands",
                table: "Brand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Blogs",
                table: "BlogTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Blogs",
                table: "BlogTag",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Blogs",
                table: "BlogTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Blogs",
                table: "BlogTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Blogs",
                table: "BlogTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Blogs",
                table: "BlogCategoryRel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Blogs",
                table: "BlogCategoryRel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Blogs",
                table: "BlogCategoryRel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Blogs",
                table: "BlogCategoryRel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Blogs",
                table: "BlogCategoryRel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Blogs",
                table: "BlogCategory",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Blogs",
                table: "BlogCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Blogs",
                table: "BlogCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Blogs",
                table: "BlogCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Blogs",
                table: "BlogCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Blogs",
                table: "BlogCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Blogs",
                table: "Blog",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                schema: "Blogs",
                table: "Blog",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                schema: "Blogs",
                table: "Blog",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "Blogs",
                table: "Blog",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                schema: "Blogs",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDesc",
                schema: "Blogs",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "Blogs",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "Blogs",
                table: "Blog",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                schema: "Blogs",
                table: "Blog",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Banners",
                table: "Banner",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmallPicture",
                schema: "Banners",
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
                schema: "Banners",
                table: "Banner",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "Banners",
                table: "Banner",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDate",
                schema: "Banners",
                table: "Banner",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Banners",
                table: "Banner",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "Attrs",
                table: "AttrValue",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Attrs",
                table: "AttrCategory",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "Attrs",
                table: "AttrCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "Attrs",
                table: "AttrAccountValue",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Attrs",
                table: "AttrAccount",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "Attrs",
                table: "AttrAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttrCategoryId",
                schema: "Attrs",
                table: "AttrAccount",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Attrs",
                table: "Attr",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "Attrs",
                table: "Attr",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IconHtmlCode",
                schema: "Attrs",
                table: "Attr",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Attrs",
                table: "Attr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Attrs",
                table: "Attr",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Attrs",
                table: "Attr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Attrs",
                table: "Attr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Attrs",
                table: "Attr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Comments",
                table: "AnswerComment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Comments",
                table: "AnswerComment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerCommentTitle",
                schema: "Comments",
                table: "AnswerComment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerCommentText",
                schema: "Comments",
                table: "AnswerComment",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                schema: "Comments",
                table: "AnswerComment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Comments",
                table: "AnswerComment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Comments",
                table: "AnswerComment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Comments",
                table: "AnswerComment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Comments",
                table: "AnswerComment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Comments",
                table: "AnswerComment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "AdminThemes",
                table: "AdminTheme",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "Theme",
                schema: "AdminThemes",
                table: "AdminTheme",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Addresses",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 13, 16, 56, 21, 822, DateTimeKind.Local).AddTicks(1013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                schema: "Addresses",
                table: "Address",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalAddress",
                schema: "Addresses",
                table: "Address",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OtherAddress",
                schema: "Addresses",
                table: "Address",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Neighbourhood",
                schema: "Addresses",
                table: "Address",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelTitle",
                schema: "Accounts",
                table: "AccountLevel",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LevelStyle",
                schema: "Accounts",
                table: "AccountLevel",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Accounts",
                table: "AccountLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Accounts",
                table: "AccountLevel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Accounts",
                table: "AccountLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Accounts",
                table: "AccountLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Accounts",
                table: "AccountLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Accounts",
                table: "AccountCategory",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "Accounts",
                table: "AccountCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Accounts",
                table: "AccountCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Accounts",
                table: "AccountCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Accounts",
                table: "AccountCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Accounts",
                table: "AccountCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Accounts",
                table: "AccountCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Accounts",
                table: "AccountAttr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Accounts",
                table: "AccountAttr",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "Accounts",
                table: "AccountAttr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "Accounts",
                table: "AccountAttr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "Accounts",
                table: "AccountAttr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Accounts",
                table: "Account",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Subtitle",
                schema: "Accounts",
                table: "Account",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "Accounts",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "Accounts",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ActionHistories",
                schema: "ActionHistories",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressIp = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockoutReason = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    OneTimeUseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OneTimeUseCodeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    BlockedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireTimeSpanBlock = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDateReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserNameType = table.Column<int>(type: "int", nullable: false),
                    StateBaseId = table.Column<int>(type: "int", nullable: true),
                    CityBaseId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                        principalSchema: "Cities",
                        principalTable: "CityBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUser_StateBase_StateBaseId",
                        column: x => x.StateBaseId,
                        principalSchema: "States",
                        principalTable: "StateBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUser_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "States",
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Faq",
                schema: "Faqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faq_FaqCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Faqs",
                        principalTable: "FaqCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFile",
                schema: "UploadedFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresse",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StateBaseId = table.Column<int>(type: "int", nullable: false),
                    CityBaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresse_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddresse_CityBase_CityBaseId",
                        column: x => x.CityBaseId,
                        principalSchema: "Cities",
                        principalTable: "CityBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddresse_StateBase_StateBaseId",
                        column: x => x.StateBaseId,
                        principalSchema: "States",
                        principalTable: "StateBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "Configs",
                table: "Config",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoriesHeadingTitlePattern", "SendNotificationState" },
                values: new object[] { null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchAttr_JobBranchId",
                schema: "Jobs",
                table: "JobBranchAttr",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranch_UserId",
                schema: "Jobs",
                table: "JobBranch",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Users",
                table: "ApplicationUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_CityBaseId",
                schema: "Users",
                table: "ApplicationUser",
                column: "CityBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_StateBaseId",
                schema: "Users",
                table: "ApplicationUser",
                column: "StateBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_StateId",
                schema: "Users",
                table: "ApplicationUser",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Users",
                table: "ApplicationUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_CategoryId",
                schema: "Faqs",
                table: "Faq",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresse_CityBaseId",
                schema: "Users",
                table: "UserAddresse",
                column: "CityBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresse_StateBaseId",
                schema: "Users",
                table: "UserAddresse",
                column: "StateBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresse_UserId",
                schema: "Users",
                table: "UserAddresse",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StateBase_StateId",
                schema: "Addresses",
                table: "Address",
                column: "StateId",
                principalSchema: "States",
                principalTable: "StateBase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_ApplicationUser_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttrAccount_AttrCategory_AttrCategoryId",
                schema: "Attrs",
                table: "AttrAccount",
                column: "AttrCategoryId",
                principalSchema: "Attrs",
                principalTable: "AttrCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Banner_JobBranch_JobBranchId",
                schema: "Banners",
                table: "Banner",
                column: "JobBranchId",
                principalSchema: "Jobs",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityBase_StateBase_StateBaseId",
                schema: "Cities",
                table: "CityBase",
                column: "StateBaseId",
                principalSchema: "States",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ApplicationUser_UserId",
                schema: "Comments",
                table: "Comment",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranch_ApplicationUser_UserId",
                schema: "Jobs",
                table: "JobBranch",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranchAttr_JobBranch_JobBranchId",
                schema: "Jobs",
                table: "JobBranchAttr",
                column: "JobBranchId",
                principalSchema: "Jobs",
                principalTable: "JobBranch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranchTag_JobBranch_JobBranchId",
                schema: "Jobs",
                table: "JobBranchTag",
                column: "JobBranchId",
                principalSchema: "Jobs",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainSlider_JobBranch_JobBranchId",
                schema: "MainSliders",
                table: "MainSlider",
                column: "JobBranchId",
                principalSchema: "Jobs",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainSlider_StateBase_StateId",
                schema: "MainSliders",
                table: "MainSlider",
                column: "StateId",
                principalSchema: "States",
                principalTable: "StateBase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ApplicationUser_UserId",
                schema: "Orders",
                table: "Order",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_JobBranch_JobBranchId",
                schema: "Orders",
                table: "Order",
                column: "JobBranchId",
                principalSchema: "Jobs",
                principalTable: "JobBranch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBannerClick_ApplicationUser_UserId",
                schema: "Users",
                table: "UserBannerClick",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBannerView_ApplicationUser_UserId",
                schema: "Users",
                table: "UserBannerView",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBlogLike_ApplicationUser_UserId",
                schema: "Users",
                table: "UserBlogLike",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookMark_ApplicationUser_UserId",
                schema: "Users",
                table: "UserBookMark",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StateBase_StateId",
                schema: "Addresses",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_ApplicationUser_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_ApplicationUser_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_ApplicationUser_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_ApplicationUser_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AttrAccount_AttrCategory_AttrCategoryId",
                schema: "Attrs",
                table: "AttrAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Banner_JobBranch_JobBranchId",
                schema: "Banners",
                table: "Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_CityBase_StateBase_StateBaseId",
                schema: "Cities",
                table: "CityBase");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ApplicationUser_UserId",
                schema: "Comments",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_JobBranch_ApplicationUser_UserId",
                schema: "Jobs",
                table: "JobBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_JobBranchAttr_JobBranch_JobBranchId",
                schema: "Jobs",
                table: "JobBranchAttr");

            migrationBuilder.DropForeignKey(
                name: "FK_JobBranchTag_JobBranch_JobBranchId",
                schema: "Jobs",
                table: "JobBranchTag");

            migrationBuilder.DropForeignKey(
                name: "FK_MainSlider_JobBranch_JobBranchId",
                schema: "MainSliders",
                table: "MainSlider");

            migrationBuilder.DropForeignKey(
                name: "FK_MainSlider_StateBase_StateId",
                schema: "MainSliders",
                table: "MainSlider");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ApplicationUser_UserId",
                schema: "Orders",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_JobBranch_JobBranchId",
                schema: "Orders",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBannerClick_ApplicationUser_UserId",
                schema: "Users",
                table: "UserBannerClick");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBannerView_ApplicationUser_UserId",
                schema: "Users",
                table: "UserBannerView");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBlogLike_ApplicationUser_UserId",
                schema: "Users",
                table: "UserBlogLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBookMark_ApplicationUser_UserId",
                schema: "Users",
                table: "UserBookMark");

            migrationBuilder.DropTable(
                name: "ActionHistories",
                schema: "ActionHistories");

            migrationBuilder.DropTable(
                name: "Faq",
                schema: "Faqs");

            migrationBuilder.DropTable(
                name: "UploadedFile",
                schema: "UploadedFiles");

            migrationBuilder.DropTable(
                name: "UserAddresse",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "Users");

            migrationBuilder.DropIndex(
                name: "IX_JobBranchAttr_JobBranchId",
                schema: "Jobs",
                table: "JobBranchAttr");

            migrationBuilder.DropIndex(
                name: "IX_JobBranch_UserId",
                schema: "Jobs",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Orders",
                table: "PromotionCode");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Orders",
                table: "PromotionCode");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Orders",
                table: "PromotionCode");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Orders",
                table: "PromotionCode");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "MainSliders",
                table: "MainSlider");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "MainSliders",
                table: "MainSlider");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "MainSliders",
                table: "MainSlider");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "MainSliders",
                table: "MainSlider");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "MainSliders",
                table: "MainSlider");

            migrationBuilder.DropColumn(
                name: "JobBranchId",
                schema: "Jobs",
                table: "JobBranchAttr");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Jobs",
                table: "JobBranch");

            migrationBuilder.DropColumn(
                name: "CategoriesHeadingTitlePattern",
                schema: "Configs",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Cities",
                table: "CityCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Cities",
                table: "CityCategory");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Cities",
                table: "CityCategory");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Cities",
                table: "CityCategory");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Cities",
                table: "CityCategory");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Cities",
                table: "CityBase");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Cities",
                table: "CityBase");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Cities",
                table: "CityBase");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Cities",
                table: "CityBase");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Cities",
                table: "CityBase");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Categories",
                table: "CategoryService");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Categories",
                table: "CategoryService");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Categories",
                table: "CategoryService");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Categories",
                table: "CategoryService");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Categories",
                table: "CategoryService");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Brands",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Brands",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Brands",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Brands",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Brands",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Blogs",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Blogs",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Blogs",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Blogs",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Blogs",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Blogs",
                table: "BlogCategoryRel");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Blogs",
                table: "BlogCategoryRel");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Blogs",
                table: "BlogCategoryRel");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Blogs",
                table: "BlogCategoryRel");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Blogs",
                table: "BlogCategoryRel");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Blogs",
                table: "BlogCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Blogs",
                table: "BlogCategory");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Blogs",
                table: "BlogCategory");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Blogs",
                table: "BlogCategory");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Blogs",
                table: "BlogCategory");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Attrs",
                table: "Attr");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Attrs",
                table: "Attr");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Attrs",
                table: "Attr");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Attrs",
                table: "Attr");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Attrs",
                table: "Attr");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Comments",
                table: "AnswerComment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Comments",
                table: "AnswerComment");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Comments",
                table: "AnswerComment");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Comments",
                table: "AnswerComment");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Comments",
                table: "AnswerComment");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Accounts",
                table: "AccountLevel");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Accounts",
                table: "AccountLevel");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Accounts",
                table: "AccountLevel");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Accounts",
                table: "AccountLevel");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Accounts",
                table: "AccountLevel");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Accounts",
                table: "AccountCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Accounts",
                table: "AccountCategory");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Accounts",
                table: "AccountCategory");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Accounts",
                table: "AccountCategory");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Accounts",
                table: "AccountCategory");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Accounts",
                table: "AccountAttr");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Accounts",
                table: "AccountAttr");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "Accounts",
                table: "AccountAttr");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "Accounts",
                table: "AccountAttr");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "Accounts",
                table: "AccountAttr");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "UsersFeedbackSlider",
                newName: "UsersFeedbackSlider",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserBookMark",
                schema: "Users",
                newName: "UserBookMark",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserBlogLike",
                schema: "Users",
                newName: "UserBlogLike",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserBannerView",
                schema: "Users",
                newName: "UserBannerView",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserBannerClick",
                schema: "Users",
                newName: "UserBannerClick",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Team",
                schema: "Teams",
                newName: "Team",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Tag",
                schema: "Tags",
                newName: "Tag",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "StateBase",
                schema: "States",
                newName: "StateBase",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "State",
                schema: "States",
                newName: "State",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ShortLink",
                schema: "ShortLinks",
                newName: "ShortLink",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Service",
                schema: "Services",
                newName: "Service",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RedirectionUrl",
                schema: "RedirectionUrls",
                newName: "RedirectionUrl",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PromotionCode",
                schema: "Orders",
                newName: "PromotionCode",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PaymentPortal",
                schema: "PaymentPortals",
                newName: "PaymentPortal",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "Orders",
                newName: "Order",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "MainSlider",
                schema: "MainSliders",
                newName: "MainSlider",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Location",
                schema: "Locations",
                newName: "Location",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobTimeWork",
                schema: "Jobs",
                newName: "JobTimeWork",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobTag",
                schema: "Jobs",
                newName: "JobTag",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobService",
                schema: "Jobs",
                newName: "JobService",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobSelectionSlider",
                schema: "Jobs",
                newName: "JobSelectionSlider",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobCategory",
                newName: "JobCategory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranchTag",
                schema: "Jobs",
                newName: "JobBranchTag",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranchShortLink",
                schema: "Jobs",
                newName: "JobBranchShortLink",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranchGallery",
                schema: "Jobs",
                newName: "JobBranchGallery",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranchAttr",
                schema: "Jobs",
                newName: "JobBranchAttr",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "JobBranch",
                schema: "Jobs",
                newName: "JobBranch",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Job",
                schema: "Jobs",
                newName: "Job",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FeedbackSlider",
                schema: "FeedbackSliders",
                newName: "FeedbackSlider",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FaqCategory",
                schema: "Faqs",
                newName: "FaqCategory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ContactUs",
                schema: "ContactUs",
                newName: "ContactUs",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Config",
                schema: "Configs",
                newName: "Config",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Comment",
                schema: "Comments",
                newName: "Comment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CityCategory",
                schema: "Cities",
                newName: "CityCategory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CityBase",
                schema: "Cities",
                newName: "CityBase",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "City",
                schema: "Cities",
                newName: "City",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CategoryService",
                schema: "Categories",
                newName: "CategoryService",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "Categories",
                newName: "Category",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Brand",
                schema: "Brands",
                newName: "Brand",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BlogTag",
                schema: "Blogs",
                newName: "BlogTag",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BlogCategoryRel",
                schema: "Blogs",
                newName: "BlogCategoryRel",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BlogCategory",
                schema: "Blogs",
                newName: "BlogCategory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Blog",
                schema: "Blogs",
                newName: "Blog",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Banner",
                schema: "Banners",
                newName: "Banner",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AttrValue",
                schema: "Attrs",
                newName: "AttrValue",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AttrCategory",
                schema: "Attrs",
                newName: "AttrCategory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AttrAccountValue",
                schema: "Attrs",
                newName: "AttrAccountValue",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AttrAccount",
                schema: "Attrs",
                newName: "AttrAccount",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Attr",
                schema: "Attrs",
                newName: "Attr",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AnswerComment",
                schema: "Comments",
                newName: "AnswerComment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AdminTheme",
                schema: "AdminThemes",
                newName: "AdminTheme",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "Addresses",
                newName: "Address",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AccountLevel",
                schema: "Accounts",
                newName: "AccountLevel",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AccountCategory",
                schema: "Accounts",
                newName: "AccountCategory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AccountAttr",
                schema: "Accounts",
                newName: "AccountAttr",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Account",
                schema: "Accounts",
                newName: "Account",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Team",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Tag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "AccountLevel",
                newName: "AccountLevelId");

            migrationBuilder.AlterColumn<string>(
                name: "PersianName",
                schema: "Schema",
                table: "DayOfWeek",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "AlternateName",
                schema: "Schema",
                table: "DayOfWeek",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "dbo",
                table: "UsersFeedbackSlider",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsApp",
                schema: "dbo",
                table: "Team",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                schema: "dbo",
                table: "Team",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                schema: "dbo",
                table: "Team",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                schema: "dbo",
                table: "Team",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "dbo",
                table: "Team",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Degree",
                schema: "dbo",
                table: "Team",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "UniqueName",
                schema: "dbo",
                table: "Tag",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Tag",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "dbo",
                table: "Tag",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IconHtmlCode",
                schema: "dbo",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "StateBase",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Subtitle",
                schema: "dbo",
                table: "State",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "dbo",
                table: "State",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                schema: "dbo",
                table: "State",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaDesc",
                schema: "dbo",
                table: "State",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "State",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ShortKey",
                schema: "dbo",
                table: "ShortLink",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceTitle",
                schema: "dbo",
                table: "Service",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceSummary",
                schema: "dbo",
                table: "Service",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ServicePicture",
                schema: "dbo",
                table: "Service",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "PromotionCode",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "PromotionCode",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "PaymentPortal",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "dbo",
                table: "PaymentPortal",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "PaymentAmount",
                schema: "dbo",
                table: "Order",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                schema: "dbo",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                schema: "dbo",
                table: "Order",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalInfo",
                schema: "dbo",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "dbo",
                table: "Order",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "MainSlider",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LinkPage",
                schema: "dbo",
                table: "MainSlider",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "MainSlider",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "Location",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                schema: "dbo",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Location",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "dbo",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                schema: "dbo",
                table: "JobTimeWork",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                schema: "dbo",
                table: "JobTimeWork",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "JobBranchTag",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ShortKey",
                schema: "dbo",
                table: "JobBranchShortLink",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                schema: "dbo",
                table: "JobBranchAttr",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SmallPicture",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaDesc",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LargePicture",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeadingTitle",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConfirmationDate",
                schema: "dbo",
                table: "JobBranch",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "BranchVideo",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BranchContent",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserOwnerId",
                schema: "dbo",
                table: "JobBranch",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "WebSiteName",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SmallPicture",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumberInfos",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LargePicture",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserRole",
                schema: "dbo",
                table: "FeedbackSlider",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "dbo",
                table: "FeedbackSlider",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "dbo",
                table: "FeedbackSlider",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "FeedbackSlider",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "FaqCategory",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                schema: "dbo",
                table: "ContactUs",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Whatsapp",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupportBoxTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupportBoxDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmsUser",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmsPass",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmsCenter",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteName",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteAlternateName",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShippingTimeRange",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "SendNotificationState",
                schema: "dbo",
                table: "Config",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ResetPasswordPatternCode",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PricingTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PricingPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PricingMetaDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PricingIconPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PriceRange",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentAccepted",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderNotificationPhoneNumber",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MailUserName",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MailSmtpDomain",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MailPassword",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MailDisplayName",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobsPersonalBrandMetaTitlePattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobsPersonalBrandMetaDescriptionPattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobsBrandNameMetaTitlePattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobsBrandNameMetaDescriptionPattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeSummery",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeMetaDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeMainPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeMainExtFileName",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HomeActiveSliderCategoryId",
                schema: "dbo",
                table: "Config",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Google",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreeAddTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreeAddPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreeAddMetaDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreeAddIconPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaqTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaqPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaqMetaDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Facebook",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Domain",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrenciesAccepted",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentDeliveryNetwork",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactMetaDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmationPatternCode",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriesPersonalBrandMetaDescriptionPattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriesMetaTitlePattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriesBrandNameMetaDescriptionPattern",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BlogTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BlogMetaDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutUsVideo",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutUsTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutUsMetaDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserIp",
                schema: "dbo",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "Comment",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "dbo",
                table: "Comment",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                schema: "dbo",
                table: "Comment",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                schema: "dbo",
                table: "Comment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "StateBaseId",
                schema: "dbo",
                table: "CityBase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "CityBase",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Subtitle",
                schema: "dbo",
                table: "City",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "City",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "dbo",
                table: "City",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                schema: "dbo",
                table: "City",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaDesc",
                schema: "dbo",
                table: "City",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "City",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                schema: "dbo",
                table: "Category",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "Category",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "PageContent",
                schema: "dbo",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Category",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                schema: "dbo",
                table: "Category",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaDesc",
                schema: "dbo",
                table: "Category",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HeadingTitle",
                schema: "dbo",
                table: "Category",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Brand",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "AlternateTitle",
                schema: "dbo",
                table: "Brand",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "BlogCategory",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaDesc",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaCanonicalUrl",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "dbo",
                table: "Blog",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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

            migrationBuilder.AlterColumn<string>(
                name: "JobBranchId",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDate",
                schema: "dbo",
                table: "Banner",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Banner",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "dbo",
                table: "AttrValue",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "AttrCategory",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "dbo",
                table: "AttrCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "dbo",
                table: "AttrAccountValue",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "AttrAccount",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "dbo",
                table: "AttrAccount",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttrCategoryId",
                schema: "dbo",
                table: "AttrAccount",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Attr",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "dbo",
                table: "Attr",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IconHtmlCode",
                schema: "dbo",
                table: "Attr",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "AnswerComment",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "dbo",
                table: "AnswerComment",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerCommentTitle",
                schema: "dbo",
                table: "AnswerComment",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerCommentText",
                schema: "dbo",
                table: "AnswerComment",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                schema: "dbo",
                table: "AnswerComment",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "AdminTheme",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Theme",
                schema: "dbo",
                table: "AdminTheme",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "Address",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 13, 16, 56, 21, 822, DateTimeKind.Local).AddTicks(1013));

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "PostalAddress",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "OtherAddress",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Neighbourhood",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelTitle",
                schema: "dbo",
                table: "AccountLevel",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LevelStyle",
                schema: "dbo",
                table: "AccountLevel",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "AccountCategory",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "dbo",
                table: "AccountCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Account",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Subtitle",
                schema: "dbo",
                table: "Account",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "dbo",
                table: "Account",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IconPicture",
                schema: "dbo",
                table: "Account",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityBaseId = table.Column<int>(type: "int", nullable: true),
                    StateBaseId = table.Column<int>(type: "int", nullable: true),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlockedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ExpireTimeSpanBlock = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDateReason = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutReason = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    OneTimeUseCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    OneTimeUseCodeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserIsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    UserNameType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_CityBase_CityBaseId",
                        column: x => x.CityBaseId,
                        principalSchema: "dbo",
                        principalTable: "CityBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_StateBase_StateBaseId",
                        column: x => x.StateBaseId,
                        principalSchema: "dbo",
                        principalTable: "StateBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BreadCrumb",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BreadCrumbAlternateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreadCrumbItemId = table.Column<int>(type: "int", nullable: false),
                    BreadCrumbPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreadCrumbPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreadCrumbPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreadCrumbTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreadCrumbType = table.Column<byte>(type: "tinyint", nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreadCrumb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintText = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsReadByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconPicture = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faqs_FaqCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "FaqCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeoLocation",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AgePerson = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageAvatarPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    SubName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuestionType = table.Column<byte>(type: "tinyint", nullable: false),
                    QuestionTypeId = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeWorks",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFiles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AuthCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    RefCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transaction_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityBaseId = table.Column<int>(type: "int", nullable: false),
                    StateBaseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddress_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddress_CityBase_CityBaseId",
                        column: x => x.CityBaseId,
                        principalSchema: "dbo",
                        principalTable: "CityBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddress_StateBase_StateBaseId",
                        column: x => x.StateBaseId,
                        principalSchema: "dbo",
                        principalTable: "StateBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBlogAction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    ActionScore = table.Column<int>(type: "int", nullable: false),
                    BlogActionType = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBlogAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBlogAction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBlogAction_Blog_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "dbo",
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJobAction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    ActionScore = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    JobActionType = table.Column<int>(type: "int", nullable: false),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserJobAction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJobAction_JobBranch_JobBranchId",
                        column: x => x.JobBranchId,
                        principalSchema: "dbo",
                        principalTable: "JobBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLikedGallery",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    JobBranchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLikedType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikedGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLikedGallery_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inventory = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Article",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    ArticleBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticlePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticlePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    PublisherOrganization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Article_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Schema",
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrandOwner",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerBrandId = table.Column<int>(type: "int", nullable: false),
                    AlternateName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandOwner_Person_OwnerBrandId",
                        column: x => x.OwnerBrandId,
                        principalSchema: "Schema",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewItem",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ItemReviewedId = table.Column<int>(type: "int", nullable: false),
                    ReviewAspect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewItemType = table.Column<byte>(type: "tinyint", nullable: false),
                    ReviewTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewItem_Person_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Schema",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CreateDateAnswer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Schema",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeClose",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeCloses = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeWorksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeClose", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeClose_TimeWorks_TimeWorksId",
                        column: x => x.TimeWorksId,
                        principalSchema: "Schema",
                        principalTable: "TimeWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeOpens",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOpen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeWorksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeOpens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeOpens_TimeWorks_TimeWorksId",
                        column: x => x.TimeWorksId,
                        principalSchema: "Schema",
                        principalTable: "TimeWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "dbo",
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalSchema: "dbo",
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayOfWeeks",
                schema: "Schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeCloseId = table.Column<int>(type: "int", nullable: true),
                    TimeOpenId = table.Column<int>(type: "int", nullable: true),
                    TimeWorkId = table.Column<int>(type: "int", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    IsSelectedPersianName = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PersianName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOfWeeks_TimeClose_TimeCloseId",
                        column: x => x.TimeCloseId,
                        principalSchema: "Schema",
                        principalTable: "TimeClose",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DayOfWeeks_TimeOpens_TimeOpenId",
                        column: x => x.TimeOpenId,
                        principalSchema: "Schema",
                        principalTable: "TimeOpens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DayOfWeeks_TimeWorks_TimeWorkId",
                        column: x => x.TimeWorkId,
                        principalSchema: "Schema",
                        principalTable: "TimeWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Config",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendNotificationState",
                value: (byte)1);

            migrationBuilder.InsertData(
                schema: "Schema",
                table: "DayOfWeek",
                columns: new[] { "Id", "AlternateName", "IsSelectedPersianName", "PersianName", "Sort" },
                values: new object[,]
                {
                    { 1, "Saturday", true, "شنبه", (byte)2 },
                    { 2, "Sunday", true, "یک شنبه", (byte)3 },
                    { 3, "Monday", true, "دوشنبه", (byte)4 },
                    { 4, "Tuesday", true, "سه شنبه", (byte)5 },
                    { 5, "Wednesday", true, "چهارشنبه", (byte)6 },
                    { 6, "Thursday", true, "پنج شنبه", (byte)7 },
                    { 7, "Friday", true, "جمعه", (byte)8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobBranchAttr_BranchId",
                schema: "dbo",
                table: "JobBranchAttr",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBranch_UserOwnerId",
                schema: "dbo",
                table: "JobBranch",
                column: "UserOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                schema: "Schema",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_AuthorId",
                schema: "Schema",
                table: "Article",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_PersonId",
                schema: "Schema",
                table: "Article",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityBaseId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "CityBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StateBaseId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "StateBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StateId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BrandOwner_OwnerBrandId",
                schema: "Schema",
                table: "BrandOwner",
                column: "OwnerBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfWeeks_TimeCloseId",
                schema: "Schema",
                table: "DayOfWeeks",
                column: "TimeCloseId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfWeeks_TimeOpenId",
                schema: "Schema",
                table: "DayOfWeeks",
                column: "TimeOpenId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfWeeks_TimeWorkId",
                schema: "Schema",
                table: "DayOfWeeks",
                column: "TimeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_CategoryId",
                schema: "dbo",
                table: "Faqs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewItem_AuthorId",
                schema: "Schema",
                table: "ReviewItem",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeClose_TimeWorksId",
                schema: "Schema",
                table: "TimeClose",
                column: "TimeWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOpens_TimeWorksId",
                schema: "Schema",
                table: "TimeOpens",
                column: "TimeWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ApplicationUserId",
                schema: "dbo",
                table: "Transaction",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_OrderId",
                schema: "dbo",
                table: "Transaction",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_CityBaseId",
                schema: "dbo",
                table: "UserAddress",
                column: "CityBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_StateBaseId",
                schema: "dbo",
                table: "UserAddress",
                column: "StateBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserId",
                schema: "dbo",
                table: "UserAddress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBlogAction_BlogId",
                schema: "dbo",
                table: "UserBlogAction",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBlogAction_UserId",
                schema: "dbo",
                table: "UserBlogAction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobAction_JobBranchId",
                schema: "dbo",
                table: "UserJobAction",
                column: "JobBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobAction_UserId",
                schema: "dbo",
                table: "UserJobAction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedGallery_UserId",
                schema: "dbo",
                table: "UserLikedGallery",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                schema: "dbo",
                table: "Wallets",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_TransactionId",
                schema: "dbo",
                table: "WalletTransactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_WalletId",
                schema: "dbo",
                table: "WalletTransactions",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StateBase_StateId",
                schema: "dbo",
                table: "Address",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "dbo",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttrAccount_AttrCategory_AttrCategoryId",
                schema: "dbo",
                table: "AttrAccount",
                column: "AttrCategoryId",
                principalSchema: "dbo",
                principalTable: "AttrCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banner_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Banner",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CityBase_StateBase_StateBaseId",
                schema: "dbo",
                table: "CityBase",
                column: "StateBaseId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                schema: "dbo",
                table: "Comment",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranch_AspNetUsers_UserOwnerId",
                schema: "dbo",
                table: "JobBranch",
                column: "UserOwnerId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranchAttr_JobBranch_BranchId",
                schema: "dbo",
                table: "JobBranchAttr",
                column: "BranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobBranchTag_JobBranch_JobBranchId",
                schema: "dbo",
                table: "JobBranchTag",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainSlider_JobBranch_JobBranchId",
                schema: "dbo",
                table: "MainSlider",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainSlider_StateBase_StateId",
                schema: "dbo",
                table: "MainSlider",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                schema: "dbo",
                table: "Order",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_JobBranch_JobBranchId",
                schema: "dbo",
                table: "Order",
                column: "JobBranchId",
                principalSchema: "dbo",
                principalTable: "JobBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBannerClick_AspNetUsers_UserId",
                schema: "dbo",
                table: "UserBannerClick",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBannerView_AspNetUsers_UserId",
                schema: "dbo",
                table: "UserBannerView",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBlogLike_AspNetUsers_UserId",
                schema: "dbo",
                table: "UserBlogLike",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
