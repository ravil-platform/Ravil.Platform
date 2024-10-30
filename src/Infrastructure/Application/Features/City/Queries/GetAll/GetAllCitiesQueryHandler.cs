using ViewModels.QueriesResponseViewModel.City;

namespace Application.Features.City.Queries.GetAll;

public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, List<CityViewModel>>
{

    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllCitiesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<CityViewModel>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.CityRepository.GetAllAsync();

        var citiesViewModel = Mapper.Map<List<CityViewModel>>(result);

        return citiesViewModel;
    }
}