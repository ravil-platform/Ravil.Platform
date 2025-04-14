namespace ViewModels.AdminPanel.Job;

public class UpdateJobBranchViewModel : BaseMetaViewModel
{
    #region (Fields)
    public string Id { get; set; }

    [Display(Name = "مسیر یکتا (انگلیسی)")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Route { get; set; } = null!;

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Title { get; set; } = null!;

    [Display(Name = "زیر عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string? HeadingTitle { get; set; }

    [Display(Name = "شرح")]
    public string? Description { get; set; }

    [Display(Name = "محتوا")]
    public string? BranchContent { get; set; }

    [Display(Name = "ویدیو")]
    public IFormFile? BranchVideoFile { get; set; }
    public string? CurrentBranchVideo { get; set; }

    [Display(Name = "تصویر دسکتاپ")]
    public IFormFile? LargePictureFile { get; set; }
    public string? CurrentPicture { get; set; }

    [Display(Name = "تصویر موبایل")]
    public IFormFile? SmallPictureFile { get; set; }
    public string? CurrentSmallPicture { get; set; }

    [Display(Name = "ساعات کاری")]
    public JobTimeWorkType JobTimeWorkType { get; set; }

    #endregion

    #region (Relations)
    public int JobId { get; set; }

    public string UserId { get; set; } = null!;
    #endregion
}