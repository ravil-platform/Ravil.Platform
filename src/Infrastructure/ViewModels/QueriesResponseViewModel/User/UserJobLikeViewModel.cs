namespace ViewModels.QueriesResponseViewModel.User;

public class UserJobLikeViewModel
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public string? JobBranchId { get; set; }
    public string? UserIp { get; set; }
        
    public bool IsLiked { get; set; }
    public int LikeCount { get; set; }
}