using ViewModels.QueriesResponseViewModel.Team;

namespace Application.Features.Team.Queries.GetAll;

public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, List<TeamViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllTeamsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<TeamViewModel>>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.TeamRepository.GetAllAsync();

        var teamViewModel = Mapper.Map<List<TeamViewModel>>(result);

        return teamViewModel;
    }
}