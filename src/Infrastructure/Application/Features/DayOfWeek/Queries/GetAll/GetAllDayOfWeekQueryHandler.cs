
namespace Application.Features.DayOfWeek.Queries.GetAll;

public class GetAllDayOfWeekQueryHandler : IRequestHandler<GetAllDayOfWeekQuery, List<DayOfWeekViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllDayOfWeekQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<DayOfWeekViewModel>>> Handle(GetAllDayOfWeekQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.DayOfWeekRepository.GetAllAsync();

        var dayOfWeekViewModel = Mapper.Map<List<DayOfWeekViewModel>>(result);

        return dayOfWeekViewModel;
    }
}