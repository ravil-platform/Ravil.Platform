using ViewModels.QueriesResponseViewModel.Tag;

namespace Application.Features.Tag.Queries.GetAll;

public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, List<TagViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllTagsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<TagViewModel>>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.TagRepository.GetAllAsync();

        var tagsViewModel = Mapper.Map<List<TagViewModel>>(result);

        return tagsViewModel;
    }
}