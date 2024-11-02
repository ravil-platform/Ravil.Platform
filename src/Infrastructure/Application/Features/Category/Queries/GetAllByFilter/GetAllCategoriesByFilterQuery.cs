
namespace Application.Features.Category.Queries.GetAllByFilter
{
    public class GetAllCategoriesByFilterQuery : IRequest<CategoryFilterViewModel>
    {
        public CategoryFilterViewModel CategoryFilterViewModel { get; set; }
    }
}
