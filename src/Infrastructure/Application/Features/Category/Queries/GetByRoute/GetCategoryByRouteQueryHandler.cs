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

        if (category is not null)
        {
            category.PageContent =
                (await UnitOfWork.CategoryRepository.ReplaceCategoryContent(category, request.CityId))!;
            category.Picture = await UnitOfWork.CategoryRepository.SetCategoryPicture(category);

            var categoryViewModel = Mapper.Map<CategoryViewModel>(category);

            return categoryViewModel;
        }
        else
        {
            var keyword = await UnitOfWork.KeywordRepository.TableNoTracking.Include(a => a.Category)
                .Where(c => c.IsActive && c.Slug == request.Route.SlugToText() || c.Slug == request.Route.ToSlug() || c.Slug == request.Route)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            if (keyword is null)
            {
                return Result.Fail(Resources.Messages.Validations.NotFoundException);
            }

            keyword.Category.PageContent = (await UnitOfWork.CategoryRepository.ReplaceCategoryContent(keyword.Category, request.CityId))!;
            keyword.Category.Picture = await UnitOfWork.CategoryRepository.SetCategoryPicture(keyword.Category);
            
            //var keywordViewModel = Mapper.Map<KeywordViewModel>(keyword);
            var categoryViewModel = Mapper.Map<CategoryViewModel>(keyword.Category);

            return categoryViewModel;
        }

        #endregion
    }
}