namespace ViewModels.AdminPanel.Job;

public class UpdateKeywordViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Title { get; set; } = null!;

    [Display(Name = "مسیر یکتا (انگلیسی)")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Slug { get; set; } = null!;

    [Display(Name = "دسته بندی")]
    public int CategoryId { get; set; }
}