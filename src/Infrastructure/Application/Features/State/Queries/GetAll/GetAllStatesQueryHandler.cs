using ViewModels.QueriesResponseViewModel.State;

namespace Application.Features.State.Queries.GetAll;

public class GetAllStatesQueryHandler : IRequestHandler<GetAllStatesQuery, List<StateViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllStatesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<StateViewModel>>> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.StateRepository.GetAllAsync();

        var statesViewModel = Mapper.Map<List<StateViewModel>>(result);

        return statesViewModel;
    }
}