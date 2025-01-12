namespace ViewModels.AdminPanel.Job;

public class CreateJobBranchViewModel : BaseMetaViewModel
{
    #region (Fields)
    [Display(Name = "مسیر یکتا (انگلیسی)")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Route { get; set; } = null!;

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Title { get; set; } = null!;

    [Display(Name = "H1 عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string? HeadingTitle { get; set; }

    [Display(Name = "شرح")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Description { get; set; } = null!;

    [Display(Name = "محتوا")]
    public string? BranchContent { get; set; }

    [Display(Name = "ویدیو")]
    public IFormFile? BranchVideoFile { get; set; }

    [Display(Name = "تصویر دسکتاپ")]
    public IFormFile? LargePictureFile { get; set; }

    [Display(Name = "تصویر موبایل")]
    public IFormFile? SmallPictureFile { get; set; }

    [Display(Name = "نقشه")]
    public string? MapUrl { get; set; }

    public bool IsAdminCreator { get; set; } = false;

    [Display(Name = "ساعات کاری")]
    public JobTimeWorkType JobTimeWorkType { get; set; }
    #endregion

    #region (Relations)
    public int JobId { get; set; }

    public string UserId { get; set; } = null!;

    public string? AddressId { get; set; }
    #endregion
}