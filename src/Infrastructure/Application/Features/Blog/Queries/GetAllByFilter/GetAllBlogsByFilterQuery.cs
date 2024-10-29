namespace Application.Features.Blog.Queries.GetAllByFilter
{
    public class GetAllBlogsByFilterQuery : IRequest<BlogFilterViewModel>
    {
        public BlogFilterViewModel BlogFilterViewModel { get; set; }
    }
}
