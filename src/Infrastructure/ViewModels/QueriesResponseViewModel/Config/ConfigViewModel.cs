namespace ViewModels.QueriesResponseViewModel.Config
{
    public class ConfigViewModel 
    {
        #region ( Fields )
        public int? Id { get; set; }

        #region ( LocalBussiness )
        public DateTime FoundingDate { get; set; }

        public string? CurrenciesAccepted { get; set; }

        public string? PaymentAccepted { get; set; }

        public string? PriceRange { get; set; }
        #endregion

        public string? SiteName { get; set; }

        public string? SiteAlternateName { get; set; }

        public string? Tel { get; set; }

        public string? OrderNotificationPhoneNumber { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Instagram { get; set; }

        public string? Telegram { get; set; }

        public string? Facebook { get; set; }

        public string? Twitter { get; set; }

        public string? Google { get; set; }

        public string? Whatsapp { get; set; }

        public string? Domain { get; set; }

        public string? SupportBoxTitle { get; set; }

        public string? SupportBoxDesc { get; set; }

        public string? HomeTitle { get; set; }

        public string? HomeSummery { get; set; }

        public string? HomeDescription { get; set; }

        public string? HomeMetaDesc { get; set; }

        public int? HomeActiveSliderCategoryId { get; set; }

        public string? ContactTitle { get; set; }

        public string? ContactMetaDesc { get; set; }

        public string? ContactContent { get; set; }

        public string? BlogTitle { get; set; }

        public string? BlogMetaDesc { get; set; }

        public string? AboutUsTitle { get; set; }

        public string? AboutUsMetaDesc { get; set; }

        public string? AboutUsVideo { get; set; }

        public string? AboutUsContent { get; set; }

        public string? PricingTitle { get; set; }

        public string? PricingMetaDesc { get; set; }

        public string? PricingPicture { get; set; }

        public string? PricingIconPicture { get; set; }

        public string? PricingContent { get; set; }

        public string? PricingAccountDescription { get; set; }

        public string? FreeAddTitle { get; set; }

        public string? FreeAddMetaDesc { get; set; }

        public string? FreeAddPicture { get; set; }

        public string? FreeAddIconPicture { get; set; }

        public string? FreeAddContent { get; set; }

        public string? CommentRules { get; set; }

        public string? MapUrl { get; set; }

        public string? FooterText { get; set; }

        public int OrderNumber { get; set; }

        public double FreeShippingLimit { get; set; }

        public double ShippingPrice { get; set; }

        public string? ShippingTimeRange { get; set; }

        public string? FaqTitle { get; set; }

        public string? FaqMetaDesc { get; set; }

        public string? FaqPicture { get; set; }

        public string? FaqContent { get; set; }

        public bool MobileSupportButtonIsShow { get; set; }

        public bool UseSliderOrVideoInHome { get; set; }

        public int? DefaultFaqCategory { get; set; }

        public int? ActiveBaseCityId { get; set; } = 245;

        public string? HomeMainPicture { get; set; }

        public string? HomeMainExtFileName { get; set; }


        #region ( SeoProperties )
        public bool NoIndexSeoPages { get; set; }

        public bool RedirectSeoPages { get; set; }

        #region CategoriPages
        public string? CategoriesHeadingTitlePattern { get; set; }

        public string? CategoriesMetaTitlePattern { get; set; }

        public string? CategoriesBrandNameMetaDescriptionPattern { get; set; }

        public string? CategoriesPersonalBrandMetaDescriptionPattern { get; set; }
        #endregion

        #region Jobs(Business)
        public string? JobsBrandNameMetaTitlePattern { get; set; }

        public string? JobsPersonalBrandMetaTitlePattern { get; set; }

        public string? JobsBrandNameMetaDescriptionPattern { get; set; }

        public string? JobsPersonalBrandMetaDescriptionPattern { get; set; }
        #endregion
        #endregion

        #endregion
    }
}
