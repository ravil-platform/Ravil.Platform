namespace ViewModels.QueriesResponseViewModel.User;

public class UserJobBookMarkViewModel
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public string? JobBranchId { get; set; }
    public string? UserIp { get; set; }
        
    public bool IsBooked { get; set; }
    public int BookCount { get; set; }
}