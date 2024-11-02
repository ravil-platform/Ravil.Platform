namespace Application.Features.Service.Queries.GetAll;

public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, List<ServiceViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllServicesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<ServiceViewModel>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.ServiceRepository.GetAllAsync(s => !s.IsDeleted);

        var serviceViewModels = Mapper.Map<List<ServiceViewModel>>(result);

        return serviceViewModels;
    }
}