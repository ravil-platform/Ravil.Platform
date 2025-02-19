namespace Application.Features.City.Queries.GetCityBaseByLocation;

public class GetCityBaseByLocationQuery : IRequest<CityInfoViewModel>
{
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;
}