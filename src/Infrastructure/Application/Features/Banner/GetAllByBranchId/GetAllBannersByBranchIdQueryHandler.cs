using ViewModels.QueriesResponseViewModel.Banner;

namespace Application.Features.Banner.GetAllByBranchId;

public class GetAllBannersByBranchIdQueryHandler : IRequestHandler<GetAllBannersByBranchIdQuery, List<BannerViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllBannersByBranchIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<BannerViewModel>>> Handle(GetAllBannersByBranchIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.BannerRepository.GetAllAsync(b => b.JobBranchId == request.JobBranchId);

        var bannerViewModel = Mapper.Map<List<BannerViewModel>>(result);

        return bannerViewModel;
    }
}