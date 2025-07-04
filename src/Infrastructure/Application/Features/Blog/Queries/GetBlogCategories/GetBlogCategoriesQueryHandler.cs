﻿namespace Application.Features.Blog.Queries.GetBlogCategories;

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

        if (blogCategories.Count is 0 || blogCategories is null)
        {
            throw new NotFoundException();
        }

        var blogCategoryViewModel = Mapper.Map<List<BlogCategoryViewModel>>(blogCategories);

        return blogCategoryViewModel;
    }
}