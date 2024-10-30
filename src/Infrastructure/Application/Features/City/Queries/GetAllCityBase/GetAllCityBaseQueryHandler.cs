using ViewModels.QueriesResponseViewModel.City;

namespace Application.Features.City.Queries.GetAllCityBase;

public class GetAllCityBaseQueryHandler : IRequestHandler<GetAllCityBaseQuery, List<CityBaseViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllCityBaseQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<CityBaseViewModel>>> Handle(GetAllCityBaseQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.CityBaseRepository.GetAllAsync();

        var cityBaseViewModel = Mapper.Map<List<CityBaseViewModel>>(result);

        return cityBaseViewModel;
    }
}