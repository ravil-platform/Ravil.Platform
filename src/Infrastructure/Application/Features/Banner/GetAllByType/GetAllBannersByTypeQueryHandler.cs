namespace Application.Features.Banner.GetAllByType;

public class GetAllBannersByTypeQueryHandler : IRequestHandler<GetAllBannersByTypeQuery, List<BannerViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllBannersByTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<BannerViewModel>>> Handle(GetAllBannersByTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.BannerRepository.GetAllAsync(b => b.BannerType == request.BannerType);

        if (result is null || result.Count is 0)
        {
            throw new NotFoundException();
        }

        var bannersViewModel = Mapper.Map<List<BannerViewModel>>(result);

        return bannersViewModel;
    }
}