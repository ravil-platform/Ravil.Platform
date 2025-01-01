namespace Application.Features.Category.Queries.GetMainCategories;

public class GetMainCategoriesQueryHandler : IRequestHandler<GetMainCategoriesQuery, List<MainCategories>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetMainCategoriesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<MainCategories>>> Handle(GetMainCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await UnitOfWork.CategoryRepository.GetMainCategories();

        var categoriesViewModel = Mapper.Map<List<MainCategories>>(categories);

        return categoriesViewModel;
    }
}