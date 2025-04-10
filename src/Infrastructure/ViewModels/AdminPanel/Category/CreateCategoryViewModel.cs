namespace ViewModels.AdminPanel.Category;

public class CreateCategoryViewModel : BaseMetaViewModel
{
    #region (Fields)
    [Display(Name = "نوع دسته")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public CategoryBusinessType Type { get; set; }


    [Display(Name = "نام دسته")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Name { get; set; } = null!;


    [Display(Name = "مسیر یکتا (انگلیسی)")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Route { get; set; } = null!;


    [Display(Name = "والد")]
    public int ParentId { get; set; }

    [Display(Name = "سطح")]
    public short NodeLevel { get; set; }


    [Display(Name = "H1 عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string HeadingTitle { get; set; } = null!;


    [Display(Name = "وضعیت")]
    public bool IsActive { get; set; } = true;

    public bool IsLastNode { get; set; }

    public bool HasAttribute { get; set; } = false;


    [Display(Name = "تصویر")]
    public IFormFile? PictureFile { get; set; } 

    [Display(Name = "آیکن")]
    public IFormFile? IconPictureFile { get; set; } 

    [Display(Name = "ترتیب")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public int Sort { get; set; }


    [Display(Name = "محتوا")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string PageContent { get; set; } = null!;


    [Display(Name = "سوالات متداول")]
    public int[]? Faqs { get; set; }

    //just for return action 
    public int? MainParentId { get; set; }
    #endregion
}

public class UpdateCategoryViewModel : BaseMetaViewModel
{
    #region (Fields)
    public int Id { get; set; }

    [Display(Name = "نوع دسته")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public CategoryBusinessType Type { get; set; }


    [Display(Name = "نام دسته")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Name { get; set; } = null!;


    [Display(Name = "مسیر یکتا (انگلیسی)")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Route { get; set; } = null!;


    [Display(Name = "والد")]
    public int ParentId { get; set; }

    [Display(Name = "سطح")]
    public short NodeLevel { get; set; }


    [Display(Name = "H1 عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string HeadingTitle { get; set; } = null!;


    [Display(Name = "وضعیت")]
    public bool IsActive { get; set; } = true;

    public bool IsLastNode { get; set; }

    public bool HasAttribute { get; set; } = false;


    [Display(Name = "تصویر")]
    public IFormFile? PictureFile { get; set; }

    public string? CurrentPictureName { get; set; }

    [Display(Name = "آیکن")]
    public IFormFile? IconPictureFile { get; set; }

    public string? CurrentIconPictureName { get; set; }

    [Display(Name = "ترتیب")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public int Sort { get; set; }


    [Display(Name = "محتوا")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string PageContent { get; set; } = null!;


    [Display(Name = "سوالات متداول")]
    public int[]? Faqs { get; set; }
    #endregion
}