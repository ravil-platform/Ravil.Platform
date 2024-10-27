using AutoMapper;
using FluentResults;
using Persistence.Contracts;
using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Category;

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
        var categories = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.ParentId == request.ParentId);

        var categoriesViewModel = Mapper.Map<List<CategoryViewModel>>(categories);

        return categoriesViewModel;
    }
}