namespace Application.Features.Config.Queries.Get;

public class GetConfigQueryHandler : IRequestHandler<GetConfigQuery, ConfigViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetConfigQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<ConfigViewModel>> Handle(GetConfigQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.ConfigRepository.GetFirstAsync();

        var configViewModel = Mapper.Map<ConfigViewModel>(result);

        return configViewModel;
    }
}