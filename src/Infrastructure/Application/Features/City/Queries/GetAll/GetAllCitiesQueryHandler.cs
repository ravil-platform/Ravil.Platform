using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.City.Queries.GetAll;

public class GetAllCitiesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IDistributedCache distributedCache)
    : IRequestHandler<GetAllCitiesQuery, List<CityViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;

    #endregion

    public async Task<Result<List<CityViewModel>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        #region ( Get All Cities Query )

        var result = await DistributedCache.GetOrSet(CacheKeys.GetAllCitiesQuery(),
            async () => await UnitOfWork.CityRepository.GetAllAsync(includes: nameof(CityBase)));

        var citiesViewModel = Mapper.Map<List<CityViewModel>>(result);

        return citiesViewModel;

        #endregion
    }
}