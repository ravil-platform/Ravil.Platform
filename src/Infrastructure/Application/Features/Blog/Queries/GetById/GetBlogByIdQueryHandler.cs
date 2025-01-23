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
        var blog = await UnitOfWork.BlogRepository.GetByPredicate(b => b.Id == request.Id, includes: nameof(UserBlogLike));

        if (blog is null)
        {
            throw new NotFoundException();
        }

        var blogViewModel = Mapper.Map<BlogViewModel>(blog);

        return blogViewModel;
    }
}