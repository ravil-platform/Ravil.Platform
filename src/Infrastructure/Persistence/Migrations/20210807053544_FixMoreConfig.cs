using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixMoreConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutUsVideo",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultFaqCategory",
                schema: "dbo",
                table: "Config",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaqContent",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaqMetaDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaqPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaqTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeAddContent",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeAddIconPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeAddMetaDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeAddPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeAddTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MobileSupportButtonIsShow",
                schema: "dbo",
                table: "Config",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PricingContent",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricingIconPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricingMetaDesc",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricingPicture",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricingTitle",
                schema: "dbo",
                table: "Config",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseSliderOrVideoInHome",
                schema: "dbo",
                table: "Config",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Config",
                columns: new[] { "Id", "AboutUsContent", "AboutUsMetaDesc", "AboutUsTitle", "AboutUsVideo", "Address", "BlogMetaDesc", "BlogTitle", "CommentRules", "ContactContent", "ContactMetaDesc", "ContactTitle", "ContentDeliveryNetwork", "CurrenciesAccepted", "DefaultFaqCategory", "Domain", "Email", "Facebook", "FaqContent", "FaqMetaDesc", "FaqPicture", "FaqTitle", "FooterText", "FoundingDate", "FreeAddContent", "FreeAddIconPicture", "FreeAddMetaDesc", "FreeAddPicture", "FreeAddTitle", "FreeShippingLimit", "Google", "HomeActiveSliderCategoryId", "HomeMetaDesc", "HomeTitle", "Instagram", "IsMultipleCreate", "MailDisplayName", "MailPassword", "MailSmtpDomain", "MailUserName", "MapUrl", "Mobile", "MobileSupportButtonIsShow", "OrderNotificationPhoneNumber", "OrderNumber", "PaymentAccepted", "PriceRange", "PricingContent", "PricingIconPicture", "PricingMetaDesc", "PricingPicture", "PricingTitle", "ShippingPrice", "ShippingTimeRange", "SiteAlternateName", "SiteName", "SmsCenter", "SmsPass", "SmsUser", "Tel", "Telegram", "Twitter", "UseSliderOrVideoInHome", "Whatsapp", "ZarinpalMerchant", "ZarinpalMode", "ZarinpalUrl" },
                values: new object[] { 1, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "https://localhost:5001", null, null, null, null, null, null, null, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, 200000.0, null, 1, null, null, null, false, null, null, null, null, null, null, false, null, 10000, null, null, null, null, null, null, null, 25000.0, null, "ravil", "راویل", null, null, null, null, null, null, false, null, null, false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Config",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AboutUsVideo",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "DefaultFaqCategory",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "FaqContent",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "FaqMetaDesc",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "FaqPicture",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "FaqTitle",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "FreeAddContent",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "FreeAddIconPicture",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "FreeAddMetaDesc",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "FreeAddPicture",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "FreeAddTitle",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "MobileSupportButtonIsShow",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "PricingContent",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "PricingIconPicture",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "PricingMetaDesc",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "PricingPicture",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "PricingTitle",
                schema: "dbo",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "UseSliderOrVideoInHome",
                schema: "dbo",
                table: "Config");
        }
    }
}
