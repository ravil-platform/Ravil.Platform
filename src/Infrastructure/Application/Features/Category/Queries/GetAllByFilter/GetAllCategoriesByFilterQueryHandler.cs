namespace Application.Features.Category.Queries.GetAllByFilter;

public class GetAllCategoriesByFilterQueryHandler : IRequestHandler<GetAllCategoriesByFilterQuery, CategoryFilterViewModel>
{
    protected CategoryFilterViewModel CategoryFilterViewModel { get; set; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    public GetAllCategoriesByFilterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<CategoryFilterViewModel>> Handle(GetAllCategoriesByFilterQuery request, CancellationToken cancellationToken)
    {
        CategoryFilterViewModel = Mapper.Map<CategoryFilterViewModel>(request);

        var query = UnitOfWork.CategoryRepository.TableNoTracking;

        #region ( Filters )
        if (CategoryFilterViewModel.ParentId != null)
        {
            query = query.Where(c => c.ParentId == CategoryFilterViewModel.ParentId);
        }

        if (CategoryFilterViewModel.Type != null)
        {
            query = query.Where(c => c.Type == CategoryFilterViewModel.Type);
        }

        if (!string.IsNullOrWhiteSpace(CategoryFilterViewModel.Name))
        {
            query = query.Where(c => c.Name == CategoryFilterViewModel.Name);
        }

        if (CategoryFilterViewModel.NodeLevel != null)
        {
            query = query.Where(c => c.NodeLevel == CategoryFilterViewModel.NodeLevel);
        }

        if (!string.IsNullOrWhiteSpace(CategoryFilterViewModel.HeadingTitle))
        {
            query = query.Where(c => c.HeadingTitle == CategoryFilterViewModel.HeadingTitle);
        }

        if (CategoryFilterViewModel.IsActive != null)
        {
            query = query.Where(c => c.IsActive == CategoryFilterViewModel.IsActive);
        }

        if (CategoryFilterViewModel.IsLastNode != null)
        {
            query = query.Where(c => c.IsLastNode == CategoryFilterViewModel.IsLastNode);
        }
        #endregion

        CategoryFilterViewModel.Build(query.Count()).SetEntities(query, Mapper);

        if (request.NodeLevel != null && request.NodeLevel == 3)
        {
            CategoryFilterViewModel.DtoEntities = await UnitOfWork.CategoryRepository.SetTargetRoutes(CategoryFilterViewModel.DtoEntities);
        }

        return await Task.FromResult(CategoryFilterViewModel);
    }
}