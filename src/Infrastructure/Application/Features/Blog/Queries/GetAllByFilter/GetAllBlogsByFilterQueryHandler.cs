using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Blog.Queries.GetAllByFilter;

public class GetAllBlogsByFilterQueryHandler(IDistributedCache distributedCache, IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllBlogsByFilterQuery, BlogFilterViewModel>
{
    #region ( Dependencies )

    protected BlogFilterViewModel BlogFilterViewModel { get; set; }

    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IMapper Mapper { get; } = mapper;

    #endregion

    public async Task<Result<BlogFilterViewModel>> Handle(GetAllBlogsByFilterQuery request, CancellationToken cancellationToken)
    {
        BlogFilterViewModel = Mapper.Map<BlogFilterViewModel>(request);

        var query = UnitOfWork.BlogRepository.TableNoTracking
            .Include(a => a.BlogUserLikes).AsQueryable();

        //TODO where....

        BlogFilterViewModel.Build(query.Count()).SetEntities(query, Mapper);

        return await Task.FromResult(BlogFilterViewModel);
    }
}