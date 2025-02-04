namespace Application.Features.Blog.Queries.GetById;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetBlogByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<BlogViewModel>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await UnitOfWork.BlogRepository.TableNoTracking.Include(a => a.BlogUserLikes)
            .SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);

        if (blog is null)
        {
            throw new NotFoundException();
        }

        var blogViewModel = Mapper.Map<BlogViewModel>(blog);

        return blogViewModel;
    }
}