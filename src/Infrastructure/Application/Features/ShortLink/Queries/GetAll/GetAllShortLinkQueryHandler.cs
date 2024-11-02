namespace Application.Features.ShortLink.Queries.GetAll;

public class GetAllShortLinkQueryHandler : IRequestHandler<GetAllShortLinkQuery, List<ShortLinkViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllShortLinkQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<ShortLinkViewModel>>> Handle(GetAllShortLinkQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.ShortLinkRepository.GetAllAsync();

        var shortLinkViewModels = Mapper.Map<List<ShortLinkViewModel>>(result);

        return shortLinkViewModels;
    }
}