namespace ViewModels.QueriesResponseViewModel.User
{
    public class UserBlogLikeViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public int BlogId { get; set; }

        public bool IsLiked { get; set; }
        public int LikeCount { get; set; }
    }
}
