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
        var result = await UnitOfWork.TagRepository.GetAllAsync();

        var tagsViewModel = Mapper.Map<List<TagViewModel>>(result);

        return tagsViewModel;
    }
}