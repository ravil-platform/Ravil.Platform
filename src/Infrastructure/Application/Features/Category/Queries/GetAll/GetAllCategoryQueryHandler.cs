using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.Category.Queries.GetAll;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryListViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IMemoryCache MemoryCache { get; }

    public GetAllCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        MemoryCache = memoryCache;
    }

    public async Task<Result<List<CategoryListViewModel>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        if (!MemoryCache.TryGetValue(nameof(GetAllCategoriesQuery), out List<CategoryListViewModel>? categoriesViewModel))
        {
            var categories = await UnitOfWork.CategoryRepository.GetAllAsync(a => a.IsActive && a.IndexMeta);

            categoriesViewModel = Mapper.Map<List<CategoryListViewModel>>(categories);

            MemoryCache.Set(nameof(GetAllCategoriesQuery), categoriesViewModel,
            options: new MemoryCacheEntryOptions 
            {
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(4200),
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(1)
            });

            return categoriesViewModel;
        }
        
        return categoriesViewModel!;
    }
}