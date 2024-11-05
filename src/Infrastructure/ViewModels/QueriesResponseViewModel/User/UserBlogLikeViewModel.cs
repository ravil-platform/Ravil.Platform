namespace ViewModels.QueriesResponseViewModel.User
{
    public class UserBlogLikeViewModel
    {
        public int Id { get; set; }

        public DateTime LikeTimeDate { get; set; } = DateTime.Now;

        public string UserId { get; set; }
        public int BlogId { get; set; }
    }
}
