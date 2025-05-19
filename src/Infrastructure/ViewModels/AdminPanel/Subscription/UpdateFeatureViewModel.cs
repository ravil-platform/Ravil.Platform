namespace ViewModels.AdminPanel.Subscription;

public class UpdateFeatureViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Title { get; set; }

    public IFormFile? IconFile { get; set; }
}