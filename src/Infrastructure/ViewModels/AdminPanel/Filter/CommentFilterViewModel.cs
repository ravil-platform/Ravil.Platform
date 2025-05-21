namespace ViewModels.AdminPanel.Filter;

public class CommentFilterViewModel : Paging<Domain.Entities.Comment.Comment>
{
    public string? Text { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FullName { get; set; }
    public string? UserIp { get; set; } 

    public CommentTypes? CommentType { get; set; }

    public bool? IsConfirmed { get; set; }

    public bool FindAll { get; set; }
}