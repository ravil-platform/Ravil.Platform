using AutoMapper;
using FluentResults;
using Persistence.Contracts;
using RNX.Mediator;
using ViewModels.Filter.Blog;

namespace Application.Features.Blogs.Queries.GetAllByFilter;

public class GetAllBlogsByFilterQueryHandler : IRequestHandler<GetAllBlogsByFilterQuery, BlogFilterViewModel>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    public GetAllBlogsByFilterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<BlogFilterViewModel>> Handle(GetAllBlogsByFilterQuery request, CancellationToken cancellationToken)
    {
        var blogQuery = UnitOfWork.BlogRepository.TableNoTracking;

        //TODO where....

        request.BlogFilterViewModel.Build(blogQuery.Count()).SetEntities(blogQuery, Mapper);

        return await Task.FromResult(request.BlogFilterViewModel);
    }
}