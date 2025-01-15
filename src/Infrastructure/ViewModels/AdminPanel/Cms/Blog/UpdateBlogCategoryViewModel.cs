using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminPanel.Cms.Blog;

public class UpdateBlogCategoryViewModel
{
    public int Id { get; set; }

    public string? CurrentIconPictureName { get; set; }

    [Display(Name = nameof(DisplayNames.Parent), ResourceType = typeof(DisplayNames))]
    public int? ParentId { get; set; }

    public string? ParentName { get; set; }

    [Display(Name = nameof(DisplayNames.Title), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    [MaxLength(MaxLength.Title, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string Title { get; set; } = null!;

    //[Display(Name = nameof(DisplayNames.Slug), ResourceType = typeof(DisplayNames))]
    //[Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    //[MaxLength(MaxLength.Slug, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    //public string Slug { get; set; } = null!;


    [Display(Name = nameof(DisplayNames.Icon), ResourceType = typeof(DisplayNames))]
    public IFormFile? IconPictureFile { get; set; }

    [Display(Name = nameof(DisplayNames.Sort), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public byte Sort { get; set; }

    [Display(Name = nameof(DisplayNames.IsActive), ResourceType = typeof(DisplayNames))]
    public bool IsDeleted { get; set; }
}