namespace Application.Features.Blog.Queries.GetAllByFilter;

public class GetAllBlogsByFilterQueryHandler : IRequestHandler<GetAllBlogsByFilterQuery, BlogFilterViewModel>
{
    protected BlogFilterViewModel BlogFilterViewModel { get; set; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    public GetAllBlogsByFilterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<BlogFilterViewModel>> Handle(GetAllBlogsByFilterQuery request, CancellationToken cancellationToken)
    {
        BlogFilterViewModel = Mapper.Map<BlogFilterViewModel>(request);

        var query = UnitOfWork.BlogRepository.TableNoTracking;

        //TODO where....

        BlogFilterViewModel.Build(query.Count()).SetEntities(query, Mapper);

        return await Task.FromResult(BlogFilterViewModel);
    }
}