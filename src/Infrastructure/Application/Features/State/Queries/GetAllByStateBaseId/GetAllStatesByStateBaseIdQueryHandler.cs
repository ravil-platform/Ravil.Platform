using ViewModels.QueriesResponseViewModel.State;

namespace Application.Features.State.Queries.GetAllByStateBaseId;

public class GetAllStatesByStateBaseIdQueryHandler : IRequestHandler<GetAllStatesByStateBaseIdQuery, List<StateViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllStatesByStateBaseIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<StateViewModel>>> Handle(GetAllStatesByStateBaseIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.StateRepository.GetAllAsync(s => s.StateBaseId == request.StateBaseId);

        var stateViewModel = Mapper.Map<List<StateViewModel>>(result);

        return stateViewModel;
    }
}