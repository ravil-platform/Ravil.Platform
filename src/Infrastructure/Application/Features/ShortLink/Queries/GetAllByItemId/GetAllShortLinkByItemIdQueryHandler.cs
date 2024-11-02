namespace Application.Features.ShortLink.Queries.GetAllByItemId;

public class GetAllShortLinkByItemIdQueryHandler : IRequestHandler<GetAllShortLinkByItemIdQuery, List<ShortLinkViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllShortLinkByItemIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<ShortLinkViewModel>>> Handle(GetAllShortLinkByItemIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.ShortLinkRepository.GetAllAsync(s => s.ItemId == request.ItemId);

        var shortLinkViewModel = Mapper.Map<List<ShortLinkViewModel>>(result);

        return shortLinkViewModel;
    }
}