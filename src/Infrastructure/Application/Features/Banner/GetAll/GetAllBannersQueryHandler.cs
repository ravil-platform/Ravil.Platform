
namespace Application.Features.Banner.GetAll;

public class GetAllBannersQueryHandler : IRequestHandler<GetAllBannersQuery, List<BannerViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllBannersQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<BannerViewModel>>> Handle(GetAllBannersQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.BannerRepository.GetAllAsync();

        var bannersViewModel = Mapper.Map<List<BannerViewModel>>(result);

        return bannersViewModel;
    }
}