
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
        var result = await UnitOfWork.CityRepository.GetAllAsync(predicate: c => c.CityBaseId == request.CityBaseId,
            includes: nameof(Domain.Entities.City.City.CityBase));

        var cityViewModel = Mapper.Map<List<CityViewModel>>(result);

        return cityViewModel;
    }
}