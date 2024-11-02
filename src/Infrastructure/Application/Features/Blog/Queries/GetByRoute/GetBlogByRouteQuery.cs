namespace Application.Features.Blog.Queries.GetByRoute
{
    public class GetBlogByRouteQuery : IRequest<BlogViewModel>
    {
        public string Route { get; set; }
    }
}
