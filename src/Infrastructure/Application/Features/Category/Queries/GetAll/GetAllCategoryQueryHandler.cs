namespace Application.Features.Category.Queries.GetAll;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<CategoryViewModel>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await UnitOfWork.CategoryRepository.GetAllAsync();

        var categoriesViewModel = Mapper.Map<List<CategoryViewModel>>(categories);

        return categoriesViewModel;
    }
}