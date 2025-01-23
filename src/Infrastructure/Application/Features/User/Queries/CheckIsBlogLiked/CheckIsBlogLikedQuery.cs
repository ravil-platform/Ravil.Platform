namespace Application.Features.User.Queries.CheckIsBlogLiked
{
    public class CheckIsBlogLikedQuery : IRequest<UserBlogLikeViewModel>
    {
        public int BlogId { get; set; }
        public string UserId { get; set; } = null!;
    }
}
