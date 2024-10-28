using AutoMapper;
using FluentResults;
using Persistence.Contracts;
using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Blog;

namespace Application.Features.Blogs.Queries.GetBlogCategories;

public class GetBlogCategoriesQueryHandler : IRequestHandler<GetBlogCategoriesQuery, List<BlogCategoryViewModel>>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    public GetBlogCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<List<BlogCategoryViewModel>>> Handle(GetBlogCategoriesQuery request, CancellationToken cancellationToken)
    {
        var blogCategories = await UnitOfWork.BlogCategoryRepository.GetAllAsync();

        var blogCategoryViewModel = Mapper.Map<List<BlogCategoryViewModel>>(blogCategories);

        return blogCategoryViewModel;
    }
}