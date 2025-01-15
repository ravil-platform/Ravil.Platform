namespace ViewModels.AdminPanel.Banner;

public class UpdateBannerViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Title { get; set; } = null!;


    [Display(Name = "توضیحات")]
    public string? Description { get; set; }

    [Display(Name = "تصویر دسکتاپ")]
    public IFormFile? LargePictureFile { get; set; }
    public string? CurrentLargePicture { get; set; }

    [Display(Name = "تصویر موبایل")]
    public IFormFile? SmallPictureFile { get; set; }
    public string? CurrentSmallPicture { get; set; }


    [Display(Name = "لینک صفحه")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string LinkPage { get; set; } = null!;

    [Display(Name = "ترتیب")]
    public byte Sort { get; set; }

    [Display(Name = "شغل")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string JobBranchId { get; set; } = null!;


    [Display(Name = "نوع")]
    public BannerType BannerType { get; set; }

    [Display(Name = "حالت")]
    public BannerPictureType BannerPictureType { get; set; }

    [Display(Name = "تاریخ انقضا")]
    public DateTime? ExpireDate { get; set; }
}