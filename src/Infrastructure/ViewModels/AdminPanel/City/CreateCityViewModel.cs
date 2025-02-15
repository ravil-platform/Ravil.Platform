namespace ViewModels.AdminPanel.City
{
    public class CreateCityViewModel
    {
        [Display(Name = nameof(DisplayNames.SubTitle), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public string Subtitle { get; set; }


        [Display(Name = nameof(DisplayNames.Route), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public string Route { get; set; }


        [Display(Name = nameof(DisplayNames.Picture), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public IFormFile PictureFile { get; set; }

        [Display(Name = nameof(DisplayNames.Status), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public bool Status { get; set; }


        public int CityBaseId { get; set; }
    }
}
