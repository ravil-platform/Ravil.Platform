using AutoMapper;
using Common.Exceptions;
using FluentResults;
using Persistence.Contracts;
using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Blog;
using ViewModels.QueriesResponseViewModel.Category;

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
        var category = await UnitOfWork.CategoryRepository.GetByPredicate(c => c.Route == request.Route);

        if (category is null)
        {
            //بعدا باید از  Resource  بیاد پیامام
            throw new AppException("یافت نشد");
        }

        var categoryViewModel = Mapper.Map<CategoryViewModel>(category);

        return categoryViewModel;
    }
}