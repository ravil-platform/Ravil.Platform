namespace ViewModels.QueriesResponseViewModel.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public CommentTypes CommentType { get; set; }

        public string CommentText { get; set; } 

        public bool IsConfirmed { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public string UserIp { get; set; }

        public string? JobBranchId { get; set; }

        public int? BlogId { get; set; }

        public string UserId { get; set; }

        public byte? Rate { get; set; }
    }
}