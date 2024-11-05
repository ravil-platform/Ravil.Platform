namespace ViewModels.QueriesResponseViewModel.User
{
    public class UserBookMarkViewModel
    {
        public UserBookMarkType UserBookMarkType { get; set; }

        public int? BlogId { get; set; }
        public string? JobBranchId { get; set; }
        public string? UserIp { get; set; }

        public string UserId { get; set; } = null!;
    }
}
