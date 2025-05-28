using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Category.Queries.GetAll;

public class GetAllCategoryQueryHandler(IMapper mapper,
    IUnitOfWork unitOfWork, IDistributedCache distributedCache)
: IRequestHandler<GetAllCategoriesQuery, List<CategoryListViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;

    #endregion

    public async Task<Result<List<CategoryListViewModel>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        #region ( Get All Categories Query )

        var categories = await DistributedCache.GetOrSet(CacheKeys.GetAllCategoriesQuery(),
        async () => await UnitOfWork.CategoryRepository.GetAllAsync(a => a.IsActive), 
            options: new DistributedCache.CacheOptions()
            {
                ExpireSlidingCacheFromMinutes = 4 * 60,
                AbsoluteExpirationCacheFromMinutes = 48 * 60
            });
        
        var categoriesViewModel = Mapper.Map<List<CategoryListViewModel>>(categories);

        return categoriesViewModel;

        #endregion
    }
}