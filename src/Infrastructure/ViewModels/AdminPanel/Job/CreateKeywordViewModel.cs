namespace ViewModels.AdminPanel.Job;

public class CreateKeywordViewModel : BaseMetaViewModel
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Title { get; set; }

    [Display(Name = "مسیر یکتا (انگلیسی)")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Slug { get; set; }

    [Display(Name = "دسته بندی")]
    public int CategoryId { get; set; }
}