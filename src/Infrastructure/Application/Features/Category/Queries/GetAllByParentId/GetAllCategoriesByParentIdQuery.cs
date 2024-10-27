using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Category;

namespace Application.Features.Category.Queries.GetAllByParentId
{
    public class GetAllCategoriesByParentIdQuery : IRequest<List<CategoryViewModel>>
    {
        public int ParentId { get; set; }
    }
}
