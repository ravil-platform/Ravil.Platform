using ViewModels.QueriesResponseViewModel.Tag;

namespace Application.Features.Tag.Queries.GetAllByType;

public class GetAllTagsByTypeQueryHandler : IRequestHandler<GetAllTagsByTypeQuery, List<TagViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllTagsByTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<TagViewModel>>> Handle(GetAllTagsByTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.TagRepository.GetAllAsync(t => t.Type == request.Type);

        var tagsViewModel = Mapper.Map<List<TagViewModel>>(result);

        return tagsViewModel;
    }
}