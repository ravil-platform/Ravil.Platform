using AngleSharp.Common;
using System.Collections;

namespace Application.Features.PanelTutorial.Queries.Get;

public class GetPanelTutorialsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetPanelTutorialsQueryHandler> logger)
: IRequestHandler<GetPanelTutorialsQuery, List<PanelTutorialViewModel>>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected Logging.Base.ILogger<GetPanelTutorialsQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<PanelTutorialViewModel>>> Handle(GetPanelTutorialsQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Panel Tutorials Query )

        try
        {
            var panelTutorials = await UnitOfWork.PanelTutorialRepository.TableNoTracking
                .OrderBy(a => a.Sort).ToListAsync(cancellationToken: cancellationToken);

            var result = Mapper.Map<List<PanelTutorialViewModel>>(panelTutorials);

            return result;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}