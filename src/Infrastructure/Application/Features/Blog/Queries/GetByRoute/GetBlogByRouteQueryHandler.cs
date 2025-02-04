
namespace Application.Features.Blog.Queries.GetByRoute;

public class GetBlogByRouteQueryHandler : IRequestHandler<GetBlogByRouteQuery, BlogViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetBlogByRouteQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<BlogViewModel>> Handle(GetBlogByRouteQuery request, CancellationToken cancellationToken)
    {
        var blog = await UnitOfWork.BlogRepository.TableNoTracking.Include(a => a.BlogUserLikes)
            .SingleOrDefaultAsync(b => b.Route == request.Route, cancellationToken: cancellationToken);

        if (blog is null)
        {
            throw new NotFoundException();
        }

        var blogViewModel = Mapper.Map<BlogViewModel>(blog);

        return blogViewModel;
    }
}