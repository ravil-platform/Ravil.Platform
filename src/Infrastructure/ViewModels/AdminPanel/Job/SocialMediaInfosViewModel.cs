namespace ViewModels.AdminPanel.Job;

public class SocialMediaInfosViewModel
{
    [Display(Name = "آدرس")]
    public string? SocialMediaLink { get; set; }

    [Display(Name = "نوع مدیا")]
    public SocialMediaTypes? SocialMediaType { get; set; }
}