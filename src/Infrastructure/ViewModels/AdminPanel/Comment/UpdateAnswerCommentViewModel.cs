namespace ViewModels.AdminPanel.Comment;

public class UpdateAnswerCommentViewModel
{
    public int Id { get; set; }

    [Display(Name = "متن کامنت")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string AnswerCommentText { get; set; } = null!;
}