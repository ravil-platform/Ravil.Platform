namespace ViewModels.AdminPanel.PanelTutorial;

public class UpdatePanelTutorialViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Title { get; set; } = null!;


    [Display(Name = "کاور ویدیو")]
    public IFormFile? CoverNameFile { get; set; }
    public string? CurrentCoverName { get; set; }

    [Display(Name = "ویدیو")]
    public IFormFile? VideoNameFile { get; set; }
    public string? CurrentVideoName { get; set; }


    [Display(Name = "زمان ویدیو")]
    public TimeSpan Time { get; set; }


    [Display(Name = "ترتیب")]
    public int Sort { get; set; }
}