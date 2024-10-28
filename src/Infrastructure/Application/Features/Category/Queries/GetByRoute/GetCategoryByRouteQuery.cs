using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Category;

namespace Application.Features.Category.Queries.GetByRoute
{
    public class GetCategoryByRouteQuery : IRequest<CategoryViewModel>
    {
        public string Route { get; set; }
    }
}
