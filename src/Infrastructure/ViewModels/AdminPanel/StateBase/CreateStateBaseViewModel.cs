namespace ViewModels.AdminPanel.StateBase
{
    public class CreateStateBaseViewModel
    {
        [Display(Name = nameof(DisplayNames.Name), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public string Name { get; set; } = null!;

        [Display(Name = "ضرب کننده")]
        public double Multiplier { get; set; } 
    }
}
