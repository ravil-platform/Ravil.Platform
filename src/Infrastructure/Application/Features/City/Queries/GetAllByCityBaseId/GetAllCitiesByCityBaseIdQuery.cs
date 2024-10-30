using ViewModels.QueriesResponseViewModel.City;

namespace Application.Features.City.Queries.GetAllByCityBaseId
{
    public class GetAllCitiesByCityBaseIdQuery : IRequest<List<CityViewModel>>
    {
        public int CityBaseId { get; set; }
    }
}
