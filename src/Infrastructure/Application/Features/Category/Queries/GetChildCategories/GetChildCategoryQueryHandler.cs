namespace Application.Features.Category.Queries.GetChildCategories;

public class GetChildCategoryQueryHandler : IRequestHandler<GetChildCategoryQuery, List<CategoryViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetChildCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<CategoryViewModel>>> Handle(GetChildCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await UnitOfWork.CategoryRepository.GetChildCategories(request.NodeLevel, request.ParentId);

        if (request.NodeLevel == 3)
        {
            //check targets and replace routes
            categories = await UnitOfWork.CategoryRepository.SetTargetRoutes(categories);
        }


        var categoriesViewModel = Mapper.Map<List<CategoryViewModel>>(categories);

        return categoriesViewModel;
    }
}