namespace ViewModels.AdminPanel.RedirectionUrl;

public class UpdateRedirectionUrlViewModel
{
    public int Id { get; set; }

    [Display(Name = "آدرس قدیمی")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string LatestUrl { get; set; } = null!;

    [Display(Name = "آدرس جدید")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string DestinationUrl { get; set; } = null!;

    [Display(Name = "نوع")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public RedirectionTypes RedirectionType { get; set; }

    [Display(Name = "وضعیت")]
    public bool Status { get; set; }
}