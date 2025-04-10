using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.Blog.Queries.GetAll;

public class GetAllBlogsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
    : IRequestHandler<GetAllBlogsQuery, List<BlogViewModel>>
{
    protected IMemoryCache MemoryCache { get; } = memoryCache;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IMapper Mapper { get; } = mapper;

    public async Task<Result<List<BlogViewModel>>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {
        if (!MemoryCache.TryGetValue(nameof(GetAllBlogsQuery), out List<BlogViewModel>? blogs))
        {
            blogs = await UnitOfWork.BlogRepository.TableNoTracking
                .ProjectTo<BlogViewModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            MemoryCache.Set(nameof(GetAllBlogsQuery), blogs, options: new MemoryCacheEntryOptions
            {
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromDays(7),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7),
            });
        }

        return blogs!;
    }
}