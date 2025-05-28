using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Config.Queries.Get;

public class GetConfigQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IDistributedCache distributedCache)
    : IRequestHandler<GetConfigQuery, ConfigViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;

    #endregion

    public async Task<Result<ConfigViewModel>> Handle(GetConfigQuery request, CancellationToken cancellationToken)
    {
        var result = await DistributedCache.GetOrSet(CacheKeys.GetConfigQuery(),
            async () => await UnitOfWork.ConfigRepository.GetFirstAsync());

        var configViewModel = Mapper.Map<ConfigViewModel>(result);

        return configViewModel;
    }
}