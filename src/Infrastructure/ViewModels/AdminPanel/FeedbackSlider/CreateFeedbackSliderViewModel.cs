namespace ViewModels.AdminPanel.FeedbackSlider;

public class CreateFeedbackSliderViewModel
{
    [Display(Name = nameof(DisplayNames.Category), ResourceType = typeof(DisplayNames))]
    public int? CategoryId { get; set; }


    [Display(Name = nameof(DisplayNames.Name), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string UserName { get; set; } = null!;


    [Display(Name = nameof(DisplayNames.UserRole), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string UserRole { get; set; } = null!;

    [Display(Name = nameof(DisplayNames.Description), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string Description { get; set; } = null!;

    [Display(Name = nameof(DisplayNames.Sort), ResourceType = typeof(DisplayNames))]
    public byte Sort { get; set; }


    [Display(Name = nameof(DisplayNames.Picture), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public IFormFile PictureFile { get; set; } = null!;
}