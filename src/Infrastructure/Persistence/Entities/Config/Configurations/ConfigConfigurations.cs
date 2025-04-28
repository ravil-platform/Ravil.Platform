namespace Persistence.Entities.Config.Configurations
{
    public class ConfigConfigurations : IEntityTypeConfiguration<Domain.Entities.Config.Config>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Config.Config> builder)
        {
            builder.ToTable("Config", DatabaseSchemas.Shared);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FoundingDate).IsRequired();
            builder.Property(c => c.CurrenciesAccepted).IsRequired(false);
            builder.Property(c => c.PaymentAccepted).IsRequired(false);
            builder.Property(c => c.PriceRange).IsRequired(false);
            builder.Property(c => c.SiteName).IsRequired(false);
            builder.Property(c => c.SiteAlternateName).IsRequired(false);
            builder.Property(c => c.Tel).IsRequired(false).HasMaxLength(MaxLength.Phone);
            builder.Property(c => c.OrderNotificationPhoneNumber).IsRequired(false).HasMaxLength(MaxLength.Phone);
            builder.Property(c => c.Mobile).IsRequired(false).HasMaxLength(MaxLength.Phone);
            builder.Property(c => c.Email).IsRequired(false).HasMaxLength(MaxLength.Email);
            builder.Property(c => c.Address).IsRequired(false).HasMaxLength(MaxLength.Address);
            builder.Property(c => c.Instagram).IsRequired(false);
            builder.Property(c => c.Telegram).IsRequired(false);
            builder.Property(c => c.Facebook).IsRequired(false);
            builder.Property(c => c.Twitter).IsRequired(false);
            builder.Property(c => c.Google).IsRequired(false);
            builder.Property(c => c.Whatsapp).IsRequired(false);
            builder.Property(c => c.ConfirmationPatternCode).IsRequired(false);
            builder.Property(c => c.ResetPasswordPatternCode).IsRequired(false);
            builder.Property(c => c.SmsCenter).IsRequired(false);
            builder.Property(c => c.SmsUser).IsRequired(false);
            builder.Property(c => c.SmsPass).IsRequired(false);
            builder.Property(c => c.MailSmtpDomain).IsRequired(false);
            builder.Property(c => c.MailUserName).IsRequired(false);
            builder.Property(c => c.MailPassword).IsRequired(false);
            builder.Property(c => c.MailDisplayName).IsRequired(false);
            builder.Property(c => c.Domain).IsRequired(false);
            builder.Property(c => c.ContentDeliveryNetwork).IsRequired(false);
            builder.Property(c => c.SupportBoxTitle).IsRequired(false);
            builder.Property(c => c.SupportBoxDesc).IsRequired(false);
            builder.Property(c => c.HomeTitle).IsRequired(false);
            builder.Property(c => c.HomeSummery).IsRequired(false);
            builder.Property(c => c.HomeDescription).IsRequired(false);
            builder.Property(c => c.HomeMetaDesc).IsRequired(false);
            builder.Property(c => c.HomeActiveSliderCategoryId).IsRequired(false);
            builder.Property(c => c.ContactTitle).IsRequired(false);
            builder.Property(c => c.ContactMetaDesc).IsRequired(false);
            builder.Property(c => c.ContactContent).IsRequired(false);
            builder.Property(c => c.BlogTitle).IsRequired(false);
            builder.Property(c => c.BlogMetaDesc).IsRequired(false);
            builder.Property(c => c.AboutUsTitle).IsRequired(false);
            builder.Property(c => c.AboutUsMetaDesc).IsRequired(false);
            builder.Property(c => c.AboutUsVideo).IsRequired(false);
            builder.Property(c => c.AboutUsContent).IsRequired(false);
            builder.Property(c => c.PricingTitle).IsRequired(false);
            builder.Property(c => c.PricingMetaDesc).IsRequired(false);
            builder.Property(c => c.PricingPicture).IsRequired(false);
            builder.Property(c => c.PricingIconPicture).IsRequired(false);
            builder.Property(c => c.PricingContent).IsRequired(false);
            builder.Property(c => c.PricingAccountDescription).IsRequired(false);
            builder.Property(c => c.FreeAddTitle).IsRequired(false);
            builder.Property(c => c.FreeAddMetaDesc).IsRequired(false);
            builder.Property(c => c.FreeAddPicture).IsRequired(false);
            builder.Property(c => c.FreeAddIconPicture).IsRequired(false);
            builder.Property(c => c.FreeAddContent).IsRequired(false);
            builder.Property(c => c.CommentRules).IsRequired(false);
            builder.Property(c => c.MapUrl).IsRequired(false);
            builder.Property(c => c.FooterText).IsRequired(false);
            builder.Property(c => c.OrderNumber).IsRequired();
            builder.Property(c => c.FreeShippingLimit).IsRequired();
            builder.Property(c => c.ShippingPrice).IsRequired();
            builder.Property(c => c.ShippingTimeRange).IsRequired(false);
            builder.Property(c => c.ZarinpalUrl).IsRequired(false);
            builder.Property(c => c.ZarinpalMode).IsRequired();
            builder.Property(c => c.ZarinpalMerchant).IsRequired(false);
            builder.Property(c => c.IsMultipleCreate).IsRequired();
            builder.Property(c => c.SendNotificationState).IsRequired();
            builder.Property(c => c.FaqTitle).IsRequired(false);
            builder.Property(c => c.FaqMetaDesc).IsRequired(false);
            builder.Property(c => c.FaqPicture).IsRequired(false);
            builder.Property(c => c.FaqContent).IsRequired(false);
            builder.Property(c => c.MobileSupportButtonIsShow).IsRequired();
            builder.Property(c => c.UseSliderOrVideoInHome).IsRequired();
            builder.Property(c => c.DefaultFaqCategory).IsRequired(false);
            builder.Property(c => c.ActiveBaseCityId).IsRequired(false);
            builder.Property(c => c.HomeMainPicture).IsRequired(false);
            builder.Property(c => c.HomeMainExtFileName).IsRequired(false);
            builder.Property(c => c.ExternalLoginState).IsRequired();
            builder.Property(c => c.NoIndexSeoPages).IsRequired();
            builder.Property(c => c.RedirectSeoPages).IsRequired();
            builder.Property(c => c.CategoriesHeadingTitlePattern).IsRequired(false);
            builder.Property(c => c.CategoriesMetaTitlePattern).IsRequired(false);
            builder.Property(c => c.CategoriesBrandNameMetaDescriptionPattern).IsRequired(false);
            builder.Property(c => c.CategoriesPersonalBrandMetaDescriptionPattern).IsRequired(false);
            builder.Property(c => c.JobsBrandNameMetaTitlePattern).IsRequired(false);
            builder.Property(c => c.JobsPersonalBrandMetaTitlePattern).IsRequired(false);
            builder.Property(c => c.JobsBrandNameMetaDescriptionPattern).IsRequired(false);
            builder.Property(c => c.JobsPersonalBrandMetaDescriptionPattern).IsRequired(false);

            builder.HasData(new Domain.Entities.Config.Config
            {
                Id = 1,
                OrderNumber = 10000,
                ShippingPrice = 25000,
                FreeShippingLimit = 200000,
                ActiveBaseCityId = 245,
                HomeActiveSliderCategoryId = 1,
                SiteName = "راویل",
                SiteAlternateName = "ravil",
                Domain = $"https://localhost:5001",
                FoundingDate = new DateTime(2021, 9, 11)
            });
        }
    }
}
