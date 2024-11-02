namespace Application.Features.Blog.Queries.GetBlogCategoriesByParentId;

public class GetBlogCategoriesByParentIdQueryHandler : IRequestHandler<GetBlogCategoriesByParentIdQuery, List<BlogCategoryViewModel>>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    public GetBlogCategoriesByParentIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<List<BlogCategoryViewModel>>> Handle(GetBlogCategoriesByParentIdQuery request, CancellationToken cancellationToken)
    {
        var blogCategories = await UnitOfWork.BlogCategoryRepository.GetAllAsync(b => b.ParentId == request.ParentId);

        var blogCategoryViewModel = Mapper.Map<List<BlogCategoryViewModel>>(blogCategories);

        return blogCategoryViewModel;
    }
}