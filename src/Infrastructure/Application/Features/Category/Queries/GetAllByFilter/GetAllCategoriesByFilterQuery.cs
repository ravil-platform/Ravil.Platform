using RNX.Mediator;
using ViewModels.Filter.Category;
using ViewModels.QueriesResponseViewModel.Category;

namespace Application.Features.Category.Queries.GetAllByFilter
{
    public class GetAllCategoriesByFilterQuery : IRequest<CategoryFilterViewModel>
    {
        public CategoryFilterViewModel CategoryFilterViewModel { get; set; }
    }
}
