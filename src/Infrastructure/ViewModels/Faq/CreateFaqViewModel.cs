using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModels.Faq
{
    public class CreateFaqViewModel
    {
        [Display(Name = nameof(DisplayNames.Question), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public string Question { get; set; } = null!;


        [Display(Name = nameof(DisplayNames.Answer), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public string Answer { get; set; } = null!;


        [Display(Name = nameof(DisplayNames.Sort), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public int Sort { get; set; }


        [Display(Name = nameof(DisplayNames.Icon), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public IFormFile File { get; set; } = null!;


        [Display(Name = nameof(DisplayNames.Category), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public int CategoryId { get; set; }

        public SelectList? FaqCategories { get; set; }
    }
}
