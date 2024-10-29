using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Blog;

namespace Application.Features.Blog.Queries.GetBlogCategoriesByParentId
{
    public class GetBlogCategoriesByParentIdQuery : IRequest<List<BlogCategoryViewModel>>
    {
        public int ParentId { get; set; }
    }
}
