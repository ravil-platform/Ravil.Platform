namespace Application.Features.Blog.Queries.GetTags
{
    public class GetBlogTagsByIdQuery : IRequest<List<BlogTagViewModel>>
    {
        public int BlogId { get; set; }
    }
}
