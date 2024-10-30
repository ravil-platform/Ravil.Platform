using ViewModels.QueriesResponseViewModel.City;

namespace Application.Features.City.Queries.GetAllByCityBaseId;

public class GetAllCitiesByCityBaseIdQueryHandler : IRequestHandler<GetAllCitiesByCityBaseIdQuery, List<CityViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllCitiesByCityBaseIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<CityViewModel>>> Handle(GetAllCitiesByCityBaseIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.CityRepository.GetAllAsync(c => c.CityBaseId == request.CityBaseId);

        var cityViewModel = Mapper.Map<List<CityViewModel>>(result);

        return cityViewModel;
    }
}