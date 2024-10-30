namespace Application.Features.Blog.Queries.GetTags;

public class GetBlogTagsByIdQueryHandler : IRequestHandler<GetBlogTagsByIdQuery, List<BlogTagViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetBlogTagsByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<BlogTagViewModel>>> Handle(GetBlogTagsByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.BlogTagRepository.GetAllAsync(b => b.BlogId == request.BlogId,null,"Tag");

        var blogTagsViewModel = Mapper.Map<List<BlogTagViewModel>>(result);

        return blogTagsViewModel;
    }
}