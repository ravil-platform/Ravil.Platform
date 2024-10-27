using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Blog;

namespace Application.Features.Blogs.Queries.GetBlogCategories
{
    public class GetBlogCategoriesQuery : IRequest<List<BlogCategoryViewModel>>
    {
    }
}
