namespace ViewModels.AdminPanel.MessageBox;

public class UpdateMessageBoxViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Description { get; set; } = null!;

    [Display(Name = "نوع پیام")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public MessageBoxType Type { get; set; }

    [Display(Name = "نام شغل")]
    public int JobId { get; set; }
}