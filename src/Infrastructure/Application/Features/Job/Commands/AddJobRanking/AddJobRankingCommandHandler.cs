using System.Collections;
using AngleSharp.Common;

namespace Application.Features.Job.Commands.AddJobRanking;

public class AddJobRankingCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    Logging.Base.ILogger<AddJobRankingCommandHandler> logger)
    : IRequestHandler<AddJobRankingCommand>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<AddJobRankingCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result> Handle(AddJobRankingCommand request, CancellationToken cancellationToken)
    {
        #region ( Add Job Ranking Command )

        #region ( Validations )

        if (request.Data.Any(a => string.IsNullOrWhiteSpace(a.PageUrl)))
        {
            Logger.LogError(exception: null, Resources.Messages.Validations.BadRequestException, new Hashtable(request.ToDictionary()));

            return Result.Fail(Resources.Messages.Validations.BadRequestException);
        }

        #endregion

        try
        {
            var jobRankingList = Mapper.Map<List<JobRankingHistory>>(request.Data);
                
            if (jobRankingList.Any())
            {
                await UnitOfWork.JobRankingHistoryRepository.InsertRangeAsync(jobRankingList);
                await UnitOfWork.SaveAsync();
            }

            return Result.Ok();
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}