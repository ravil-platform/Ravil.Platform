namespace Application.Features.State.Queries.GetAllStateBase;

public class GetAllStateBaseQueryHandler : IRequestHandler<GetAllStateBaseQuery, List<StateBaseViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllStateBaseQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<StateBaseViewModel>>> Handle(GetAllStateBaseQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.StateBaseRepository.GetAllAsync();

        var stateBasesViewModel = Mapper.Map<List<StateBaseViewModel>>(result);

        return stateBasesViewModel;
    }
}