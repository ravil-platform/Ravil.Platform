namespace ViewModels.AdminPanel.Job;

public class CreateJobViewModel
{
    [Display(Name = "مسیر یکتا (انگلیسی)")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Route { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Title { get; set; }

    [Display(Name = "زیر عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string SubTitle { get; set; }

    [Display(Name = "خلاصه")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(512, MinimumLength = 50, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Summary { get; set; }

    [Display(Name = "محتوا")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Content { get; set; }

    [Display(Name = "تصویر بزرگ")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public IFormFile LargePictureFile { get; set; }

    [Display(Name = "تصویر کوچک")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public IFormFile SmallPictureFile { get; set; }

    [Display(Name = "صاحب کسب وکار")]
    public string? UserOwnerId { get; set; }

    [Display(Name = "برند")]
    public int? JobBrandId { get; set; }

    #region ( Contact Informations Data )

    [Display(Name = "ایمیل")]
    public string? Email { get; set; }

    [Display(Name = "وبسایت")]
    public string? WebSiteName { get; set; }

    [Display(Name = "آدرس شبکه های اجتماعی")]
    public List<SocialMediaInfosViewModel>? SocialMediaInfos { get; set; }

    [Display(Name = "شماره تماس")]
    public List<PhoneNumberInfosViewModel>? PhoneNumberInfos { get; set; }

    #region Additional PhoneNumberInfos

    [Display(Name = "عدم نمایش شماره تلفن ثابت در سایت")]
    public bool ShowPhoneTelInSite { get; set; }

    [Display(Name = "نمایش شماره تلفن همراه بالاتر از شماره تلفن ثابت باشد")]
    public bool ShowFirstPhoneMobileInSite { get; set; }
    #endregion
    #endregion

    #region ( Meta Seo )
    [Display(Name = "توضیحات متا")]
    [StringLength(256, MinimumLength = 50, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string? MetaDesc { get; set; }

    [Display(Name = "عنوان متا")]
    [StringLength(256, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string? MetaTitle { get; set; }
    #endregion

    [Display(Name = "دسته بندی")]
    public int[] Categories { get; set; }

    [Display(Name = "تگ ها")]
    public int[]? Tags { get; set; }
}

public class UserPhoneNumberViewModel
{
    public string? Id { get; set; }
    public string? PhoneNumber { get; set; }
}