namespace Application.Features.Category.Queries.GetByRoute;

public class GetCategoryByRouteQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCategoryByRouteQuery, CategoryViewModel>
{
    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<Result<CategoryViewModel>> Handle(GetCategoryByRouteQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Category By Route )

        var category = await UnitOfWork.CategoryRepository.GetByPredicate(c => c.IsActive 
            && c.Route == request.Route.SlugToText() || c.Route == request.Route.ToSlug() || c.Route == request.Route);

        if (category is null)
        {
            return Result.Fail(Resources.Messages.Validations.NotFoundException);
        }

        category.PageContent = (await UnitOfWork.CategoryRepository.ReplaceCategoryContent(category, request.CityId))!;
        category.Picture = await UnitOfWork.CategoryRepository.SetCategoryPicture(category);

        var categoryViewModel = Mapper.Map<CategoryViewModel>(category);

        return categoryViewModel;

        #endregion
    }
}