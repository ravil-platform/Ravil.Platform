namespace ViewModels.AdminPanel.Subscription;

public class CreateFeatureViewModel
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Title { get; set; }
}