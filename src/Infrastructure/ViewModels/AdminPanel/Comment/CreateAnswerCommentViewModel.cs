namespace ViewModels.AdminPanel.Comment;

public class CreateAnswerCommentViewModel
{
    public string? AdminId { get; set; }

    public bool IsAdminAnswer { get; set; } = false;

    public string UserIp { get; set; } = null!;

    [Display(Name = "عنوان کامنت")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string? AnswerCommentTitle { get; set; }


    [Display(Name = "متن کامنت")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string AnswerCommentText { get; set; } = null!;

    public DateTime AnswerCommentDate { get; set; } = DateTime.Now;
    public DateTime? ReviewDate { get; set; } = DateTime.Now;

    public bool IsConfirmed { get; set; } = true;

    public string? FullName { get; set; }

    public int CommentId { get; set; }
}