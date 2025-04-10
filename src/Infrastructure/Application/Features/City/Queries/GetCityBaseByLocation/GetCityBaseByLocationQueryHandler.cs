using ViewModels.AdminPanel.Job;
using Application.Services.NehsanApi;

namespace Application.Features.City.Queries.GetCityBaseByLocation;

public class GetCityBaseByLocationQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, NeshanApiService neshanApiService)
    : IRequestHandler<GetCityBaseByLocationQuery, CityInfoViewModel>
{
    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected NeshanApiService NeshanApiService { get; } = neshanApiService;


    public async Task<Result<CityInfoViewModel>> Handle(GetCityBaseByLocationQuery request, CancellationToken cancellationToken)
    {
        LocationDataViewModel? locationDataViewModel = await NeshanApiService.GetReverseGeocodeAsync(request.Latitude, request.Longitude);

        if (locationDataViewModel != null)
        {
            var result = await NeshanApiService.GetCityState(locationDataViewModel.City, locationDataViewModel.State, locationDataViewModel.Neighbourhood, UnitOfWork);
            var cityBaseViewModel = Mapper.Map<CityInfoViewModel>(result);

            cityBaseViewModel.Neighbourhood = locationDataViewModel.Neighbourhood;
            return cityBaseViewModel;
        }

        return Result.Fail(Resources.Messages.Validations.NotFoundException);
    }
}