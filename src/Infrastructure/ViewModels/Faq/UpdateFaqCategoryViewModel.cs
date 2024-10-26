using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModels.Faq;

public class UpdateFaqCategoryViewModel
{
    public int Id { get; set; }

    [Display(Name = nameof(DisplayNames.Title), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string Title { get; set; } = null!;

    [Display(Name = nameof(DisplayNames.Sort), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public byte Sort { get; set; }

    [Display(Name = nameof(DisplayNames.Parent), ResourceType = typeof(DisplayNames))]
    public int? ParentId { get; set; }

    public SelectList? FaqCategories { get; set; }

    public string? ParentName { get; set; }
}