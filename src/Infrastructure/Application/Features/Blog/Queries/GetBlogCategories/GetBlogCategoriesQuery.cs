using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Blog;

namespace Application.Features.Blog.Queries.GetBlogCategories
{
    public class GetBlogCategoriesQuery : IRequest<List<BlogCategoryViewModel>>
    {
    }
}
