namespace Application.Features.Category.Queries.GetByRoute;

public class GetCategoryByRouteQueryHandler : IRequestHandler<GetCategoryByRouteQuery, CategoryViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetCategoryByRouteQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<CategoryViewModel>> Handle(GetCategoryByRouteQuery request, CancellationToken cancellationToken)
    {
        var category = await UnitOfWork.CategoryRepository.GetByPredicate(c => c.Route == request.Route.SlugToText() ||  c.Route == request.Route.ToSlug() || c.Route == request.Route);

        if (category is null)
        {
            return Result.Fail(Resources.Messages.Validations.NotFoundException);
        }

        category.PageContent = (await UnitOfWork.CategoryRepository.ReplaceCategoryContent(category, request.CityId))!;
        category.Picture = (await UnitOfWork.CategoryRepository.SetCategoryPicture(category));

        var categoryViewModel = Mapper.Map<CategoryViewModel>(category);

        return categoryViewModel;
    }
}