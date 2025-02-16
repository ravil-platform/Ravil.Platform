namespace Application.Features.Tag.Queries.GetTagsByCategoryId;

public class GetTagsByCategoryIdQueryHandler : IRequestHandler<GetTagsByCategoryIdQuery, List<TagViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetTagsByCategoryIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<TagViewModel>>> Handle(GetTagsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        //todo : create method in repository to get tags by category id

        var result = await UnitOfWork.CategoryTagRepository.TableNoTracking.Where(t => t.CategoryId == request.CategoryId).Select(t => t.Tag).ToListAsync(cancellationToken);

        var tagsViewModel = Mapper.Map<List<TagViewModel>>(result);

        return tagsViewModel;
    }
}