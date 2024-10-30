namespace Application.Features.Category.Queries.GetAllCategoryService;

public class GetAllCategoryServiceQueryHandler : IRequestHandler<GetAllCategoryServiceQuery, List<CategoryServiceViewModel>>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    public GetAllCategoryServiceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<List<CategoryServiceViewModel>>> Handle(GetAllCategoryServiceQuery request, CancellationToken cancellationToken)
    {
        ICollection<CategoryService?> categoryService = new List<CategoryService?>();

        if (request.ServiceId == null && request.CategoryId == null)
        {
            categoryService = await UnitOfWork.CategoryServiceRepository.GetAllAsync();
        }
        else if (request.ServiceId != null && request.CategoryId == null)
        {
            categoryService = await UnitOfWork.CategoryServiceRepository.GetAllAsync(c => c.ServiceId == request.ServiceId);
        }
        else if (request.CategoryId != null && request.ServiceId == null)
        {
            categoryService = await UnitOfWork.CategoryServiceRepository.GetAllAsync(c => c.CategoryId == request.CategoryId);
        }

        var categoryServiceViewModel = Mapper.Map<List<CategoryServiceViewModel>>(categoryService);

        return categoryServiceViewModel;
    }
}