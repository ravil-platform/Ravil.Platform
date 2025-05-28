using System.Collections;
using AngleSharp.Common;
using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Commands.AddJobRanking;

public class AddJobRankingCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IDistributedCache distributedCache,
    UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor,
    Logging.Base.ILogger<AddJobRankingCommandHandler> logger)
: IRequestHandler<AddJobRankingCommand>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
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

            #region ( Remove Cache Data )

            foreach (var item in request.Data)
            {
                //var cache = await DistributedCache.GetAsync<List<JobRankingViewModel>>(key: CacheKeys.GetJobRankingsByFilterQuery(Convert.ToInt32(item.JobId)));
                await DistributedCache.RemoveAsync(key: CacheKeys.GetJobRankingsByFilterQuery(Convert.ToInt32(item.JobId)), cancellationToken);
            }

            #endregion

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