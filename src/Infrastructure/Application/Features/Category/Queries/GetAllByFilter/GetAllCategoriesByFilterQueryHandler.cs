using AutoMapper;
using FluentResults;
using Persistence.Contracts;
using RNX.Mediator;
using ViewModels.Filter.Category;

namespace Application.Features.Category.Queries.GetAllByFilter;

public class GetAllCategoriesByFilterQueryHandler : IRequestHandler<GetAllCategoriesByFilterQuery, CategoryFilterViewModel>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    public GetAllCategoriesByFilterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<CategoryFilterViewModel>> Handle(GetAllCategoriesByFilterQuery request, CancellationToken cancellationToken)
    {
        var categoryQuery = UnitOfWork.CategoryRepository.TableNoTracking;

        //where....

        if (request.CategoryFilterViewModel.ParentId != null)
        {
            categoryQuery = categoryQuery.Where(c => c.ParentId == request.CategoryFilterViewModel.ParentId);
        }

        if (request.CategoryFilterViewModel.Type != null)
        {
            categoryQuery = categoryQuery.Where(c => c.Type == request.CategoryFilterViewModel.Type);
        }

        if (!string.IsNullOrWhiteSpace(request.CategoryFilterViewModel.Name))
        {
            categoryQuery = categoryQuery.Where(c => c.Name == request.CategoryFilterViewModel.Name);
        }

        if (request.CategoryFilterViewModel.NodeLevel != null)
        {
            categoryQuery = categoryQuery.Where(c => c.NodeLevel == request.CategoryFilterViewModel.NodeLevel);
        }

        if (!string.IsNullOrWhiteSpace(request.CategoryFilterViewModel.HeadingTitle))
        {
            categoryQuery = categoryQuery.Where(c => c.HeadingTitle == request.CategoryFilterViewModel.HeadingTitle);
        }

        if (request.CategoryFilterViewModel.IsActive != null)
        {
            categoryQuery = categoryQuery.Where(c => c.IsActive == request.CategoryFilterViewModel.IsActive);
        }

        if (request.CategoryFilterViewModel.IsLastNode != null)
        {
            categoryQuery = categoryQuery.Where(c => c.IsLastNode == request.CategoryFilterViewModel.IsLastNode);
        }

        request.CategoryFilterViewModel.Build(categoryQuery.Count()).SetEntities(categoryQuery, Mapper);

        return await Task.FromResult(request.CategoryFilterViewModel);
    }
}