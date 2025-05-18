namespace Application.Features.Category.Queries.GetAllByParentId;

public class GetAllCategoryByParentIdQueryHandler : IRequestHandler<GetAllCategoriesByParentIdQuery, List<CategoryViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllCategoryByParentIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<CategoryViewModel>>> Handle(GetAllCategoriesByParentIdQuery request, CancellationToken cancellationToken)
    {
        var categories = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.IsActive && c.ParentId == request.ParentId);

        if (categories.Count == 0)
        {
            return Result.Fail(Resources.Messages.Validations.NotFoundException);
        }

        var categoriesViewModel = Mapper.Map<List<CategoryViewModel>>(categories);

        return categoriesViewModel;
    }
}