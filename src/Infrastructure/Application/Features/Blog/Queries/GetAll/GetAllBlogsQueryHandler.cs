using Constants.Caching;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Blog.Queries.GetAll;

public class GetAllBlogsQueryHandler(IUnitOfWork unitOfWork,
    IMapper mapper, IDistributedCache distributedCache)
: IRequestHandler<GetAllBlogsQuery, List<BlogViewModel>>
{
    #region ( Dependencies )

    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IMapper Mapper { get; } = mapper;

    #endregion

    public async Task<Result<List<BlogViewModel>>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {
        #region ( Get All Blogs Query )

        var blogs = await DistributedCache.GetOrSet(CacheKeys.GetAllBlogsQuery(),
        async () => await UnitOfWork.BlogRepository.TableNoTracking
            .ProjectTo<BlogViewModel>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken));

        if (blogs is null)
        {
            return Result.Ok(new List<BlogViewModel>());
        }

        return blogs!;

        #endregion
    }
}