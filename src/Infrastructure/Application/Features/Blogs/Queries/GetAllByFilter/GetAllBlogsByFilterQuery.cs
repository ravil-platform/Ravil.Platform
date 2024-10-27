using RNX.Mediator;
using ViewModels.Filter.Blog;

namespace Application.Features.Blogs.Queries.GetAllByFilter
{
    public class GetAllBlogsByFilterQuery : IRequest<BlogFilterViewModel>
    {
        public BlogFilterViewModel BlogFilterViewModel { get; set; }
    }
}
