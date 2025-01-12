namespace ViewModels.AdminPanel.Cms.Blog;

public class UpdateBlogViewModel : BaseMetaViewModel
{
    public int Id { get; set; }

    [Display(Name = nameof(DisplayNames.Title), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    [MaxLength(MaxLength.Title, ErrorMessageResourceName = nameof(Validations.MaxLength), ErrorMessageResourceType = typeof(Validations))]
    public string Title { get; set; } = null!;


    [Display(Name = nameof(DisplayNames.Summary), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    [MaxLength(MaxLength.Summary, ErrorMessageResourceName = nameof(Validations.MaxLength), ErrorMessageResourceType = typeof(Validations))]
    public string Summary { get; set; } = null!;


    [Display(Name = nameof(DisplayNames.Content), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string Content { get; set; } = null!;


    [Display(Name = nameof(DisplayNames.Slug), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    [MaxLength(MaxLength.Slug, ErrorMessageResourceName = nameof(Validations.MaxLength), ErrorMessageResourceType = typeof(Validations))]
    public string Route { get; set; } = null!;


    [Display(Name = nameof(DisplayNames.Picture), ResourceType = typeof(DisplayNames))]
    public IFormFile? PictureFile { get; set; }


    [Display(Name = nameof(DisplayNames.MobilePicture), ResourceType = typeof(DisplayNames))]
    public IFormFile? MobilePictureFile { get; set; }


    public string? CurrentPictureName { get; set; }
    public string? CurrentMobilePictureName { get; set; }

    [Display(Name = nameof(DisplayNames.IsActive), ResourceType = typeof(DisplayNames))]
    public bool IsDelete { get; set; }


    [Display(Name = nameof(DisplayNames.ReadingTime), ResourceType = typeof(DisplayNames))]
    public short? ReadingTime { get; set; }


    public int BlogCategoryId { get; set; }
}