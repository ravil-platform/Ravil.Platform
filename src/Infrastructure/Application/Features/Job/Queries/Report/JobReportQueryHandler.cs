using System.Collections;
using AngleSharp.Common;
using Resources.Messages;
using ViewModels.QueriesResponseViewModel.Subscription;

namespace Application.Features.Job.Queries.Report;

public class JobReportQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<JobReportQueryHandler> logger,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<JobReportQuery, List<SubscriptionClickViewModel>>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<JobReportQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<SubscriptionClickViewModel>>> Handle(JobReportQuery request, CancellationToken cancellationToken)
    {
        #region ( Get All Job Reports Query )

        #region ( Validations )

        if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
        {
            return Result.Fail(Validations.BadRequestException);
        }

        #endregion

        try
        {
            var query = UnitOfWork.SubscriptionClickRepository.TableNoTracking
                .Include(a => a.Click)
                .Where(a => a.Click.Type == request.ClickType)
                .Where(a => a.JobId == request.JobId)
                .OrderByDescending(a => a.ClickedTime)
                .AsQueryable();

            if (request is { FromDate: not null, ToDate: not null })
            {
                var fromDate = DateTimeOffset.FromUnixTimeSeconds(request.FromDate.Value);
                var toDate = DateTimeOffset.FromUnixTimeSeconds(request.ToDate.Value);

                query = query.Where(a => a.ClickedTime.Day >= fromDate.Day && a.ClickedTime.Day <= toDate.Day);
            }
            else
            {
                query = query.Where(a => a.ClickedTime.Day == DateTime.Now.Day - 1);
            }
                
            var subscriptionClicks = await query
                .ToListAsync(cancellationToken: cancellationToken);

            var result = Mapper.Map<List<SubscriptionClickViewModel>>(subscriptionClicks);

            return result;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));

            await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);
            throw;
        }

        #endregion
    }
}