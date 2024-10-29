using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Blog;

namespace Application.Features.Blog.Queries.GetByRoute
{
    public class GetBlogByRouteQuery : IRequest<BlogViewModel>
    {
        public string Route { get; set; }
    }
}
