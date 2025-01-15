namespace ViewModels.AdminPanel.Config;

public class AdminConfigViewModel
{
    #region (Fields)
    public int? Id { get; set; }

    #region ( LocalBussiness )
    public DateTime FoundingDate { get; set; }

    public string? CurrenciesAccepted { get; set; }

    public string? PaymentAccepted { get; set; }

    public string? PriceRange { get; set; }
    #endregion

    #region ( Basic Information )
    public string? SiteName { get; set; }

    public string? SiteAlternateName { get; set; }

    public string? Tel { get; set; }

    public string? OrderNotificationPhoneNumber { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }
    #endregion

    #region ( Social Medias )
    public string? Instagram { get; set; }

    public string? Telegram { get; set; }

    public string? Facebook { get; set; }

    public string? Twitter { get; set; }

    public string? Google { get; set; }

    public string? Whatsapp { get; set; }
    #endregion

    #region ( Sms Services )
    public string? ConfirmationPatternCode { get; set; }

    public string? ResetPasswordPatternCode { get; set; }

    public string? SmsCenter { get; set; }

    public string? SmsUser { get; set; }

    public string? SmsPass { get; set; }
    #endregion

    #region ( Mail Services )
    public string? MailSmtpDomain { get; set; }

    public string? MailUserName { get; set; }

    public string? MailPassword { get; set; }

    public string? MailDisplayName { get; set; }
    #endregion

    #region ( Cdn Information )
    public string? ContentDeliveryNetwork { get; set; }
    public string? Domain { get; set; }
    #endregion

    #region ( Pages Information  )
    #region ( Home )
    public string? HomeTitle { get; set; }

    public string? HomeSummery { get; set; }

    public string? HomeDescription { get; set; }

    public string? HomeMetaDesc { get; set; }

    public int? HomeActiveSliderCategoryId { get; set; }
    #endregion

    #region ( About Us )
    public string? AboutUsTitle { get; set; }

    public string? AboutUsMetaDesc { get; set; }

    public IFormFile? AboutUsVideoFile { get; set; }

    public string? AboutUsContent { get; set; }
    #endregion

    #region ( Contact )
    public string? ContactTitle { get; set; }

    public string? ContactMetaDesc { get; set; }

    public string? ContactContent { get; set; }
    #endregion

    #region ( Support )
    public string? SupportBoxTitle { get; set; }

    public string? SupportBoxDesc { get; set; }

    #endregion

    #region ( Blog )
    public string? BlogTitle { get; set; }
    public string? BlogMetaDesc { get; set; }
    #endregion

    #region ( Pricing )
    public string? PricingTitle { get; set; }

    public string? PricingMetaDesc { get; set; }

    public string? PricingPicture { get; set; }

    public string? PricingIconPicture { get; set; }

    public string? PricingContent { get; set; }

    public string? PricingAccountDescription { get; set; }
    #endregion

    #region ( Free Add )
    public string? FreeAddTitle { get; set; }
    public string? FreeAddMetaDesc { get; set; }
    public string? FreeAddContent { get; set; }

    public IFormFile? FreeAddPictureFile { get; set; }
    public IFormFile? FreeAddIconPictureFile { get; set; }
    #endregion

    #region ( Faq )
    public string? FaqTitle { get; set; }
    public string? FaqMetaDesc { get; set; }
    public string? FaqContent { get; set; }

    public IFormFile? FaqPictureFile { get; set; }
    #endregion

    public string? CommentRules { get; set; }

    public string? MapUrl { get; set; }

    public string? FooterText { get; set; }

    public int OrderNumber { get; set; }

    public double FreeShippingLimit { get; set; }

    public double ShippingPrice { get; set; }

    public string? ShippingTimeRange { get; set; }

    #endregion

    #region ( Payments Information )
    public string? ZarinpalUrl { get; set; }

    public bool ZarinpalMode { get; set; }

    public string? ZarinpalMerchant { get; set; }
    #endregion

    public bool IsMultipleCreate { get; set; } = false;

    public SendNotificationStateMode SendNotificationState { get; set; }

    public bool MobileSupportButtonIsShow { get; set; }

    public bool UseSliderOrVideoInHome { get; set; }

    public int? DefaultFaqCategory { get; set; }

    public int? ActiveBaseCityId { get; set; } = 245;

    public string? HomeMainPicture { get; set; }

    public string? HomeMainExtFileName { get; set; }

    #region ( Seo Properties )

    [Display(Name = "تمامی صفحات سئو noindex شود؟")]
    public bool NoIndexSeoPages { get; set; }

    [Display(Name = "تمامی صفحات سئو redirect شود؟")]
    public bool RedirectSeoPages { get; set; }

    #region Category Pages
    
    [Display(Name = "الگوی عنوان متا")]
    [StringLength(300, ErrorMessage = "{0} نباید بشتراز {1} کاراکتر باشد")]
    public string? CategoriesMetaTitlePattern { get; set; }

    [Display(Name = "الگوی توضیحات متا دسته بندی در حالت BrandName")]
    [StringLength(500, ErrorMessage = "{0} نباید بشتراز {1} کاراکتر باشد")]
    public string? CategoriesBrandNameMetaDescriptionPattern { get; set; }

    [Display(Name = "الگوی توضیحات متا دسته بندی در حالت PersonalBrand")]
    [StringLength(500, ErrorMessage = "{0} نباید بشتراز {1} کاراکتر باشد")]
    public string? CategoriesPersonalBrandMetaDescriptionPattern { get; set; }

    #endregion

    #region Jobs(Business)
    [Display(Name = "الگوی عنوان متا کسب و کار در حالت BrandName")]
    [StringLength(300, ErrorMessage = "{0} نباید بشتراز {1} کاراکتر باشد")]
    public string JobsBrandNameMetaTitlePattern { get; set; }

    [Display(Name = "الگوی عنوان متا کسب و کار در حالت PersonalBrand")]
    [StringLength(300, ErrorMessage = "{0} نباید بشتراز {1} کاراکتر باشد")]
    public string JobsPersonalBrandMetaTitlePattern { get; set; }

    [Display(Name = "الگوی توضیحات متا کسب و کار در حالت BrandName")]
    [StringLength(800, ErrorMessage = "{0} نباید بشتراز {1} کاراکتر باشد")]
    public string JobsBrandNameMetaDescriptionPattern { get; set; }

    [Display(Name = "الگوی توضیحات متا کسب و کار در حالت PersonalBrand")]
    [StringLength(800, ErrorMessage = "{0} نباید بشتراز {1} کاراکتر باشد")]
    public string JobsPersonalBrandMetaDescriptionPattern { get; set; }

    #endregion

    #endregion

    public ExternalLoginState ExternalLoginState { get; set; } = ExternalLoginState.WithOutViewPage;
    #endregion
}