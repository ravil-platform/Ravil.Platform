using ViewModels.QueriesResponseViewModel.Search;

namespace Application.Features.Search.Queries
{
    public class SearchByCategoryAndJobQuery : IRequest<SearchByCategoryAndJobQueryViewModel>
    {
        public string? Name { get; set; }
        public string? CityName { get; set; }
    }
}
