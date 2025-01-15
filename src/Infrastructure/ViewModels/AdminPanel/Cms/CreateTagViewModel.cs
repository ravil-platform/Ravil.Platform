namespace ViewModels.AdminPanel.Cms;

public class CreateTagViewModel
{
    [Display(Name = nameof(DisplayNames.Name), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    [MaxLength(MaxLength.Name, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string Name { get; set; } = null!;

    [Display(Name = nameof(DisplayNames.Name), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    [MaxLength(MaxLength.Name, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string UniqueName { get; set; } = null!;

    [Display(Name = nameof(DisplayNames.Icon), ResourceType = typeof(DisplayNames))]
    public IFormFile IconPictureFile { get; set; } = null!;

    public string IconHtmlCode { get; set; } = null!;

    [Display(Name = nameof(DisplayNames.Status), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public bool Status { get; set; }

    [Display(Name = nameof(DisplayNames.Type), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public TagType Type { get; set; }
}

public class UpdateTagViewModel
{
    public int Id { get; set; }

    [Display(Name = nameof(DisplayNames.Name), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    [MaxLength(MaxLength.Name, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string Name { get; set; } = null!;

    [Display(Name = nameof(DisplayNames.Name), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    [MaxLength(MaxLength.Name, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string UniqueName { get; set; } = null!;

    [Display(Name = nameof(DisplayNames.Icon), ResourceType = typeof(DisplayNames))]
    public IFormFile? IconPictureFile { get; set; }

    public string? CurrentIconPicture { get; set; }

    public string IconHtmlCode { get; set; } = null!;

    [Display(Name = nameof(DisplayNames.Status), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public bool Status { get; set; }

    [Display(Name = nameof(DisplayNames.Type), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public TagType Type { get; set; }
}