namespace Application.Features.User.Commands.AddBlogLike
{
    public class AddBlogLikeCommand : IRequest
    {
        public string UserId { get; set; }
        public int BlogId { get; set; }
    }
}
