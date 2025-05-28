using AngleSharp.Common;
using System.Collections;
using Domain.Entities.Subscription;
using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Commands.AdsClickActivity;

public class AdsClickActivityCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor, 
    Logging.Base.ILogger<AdsClickActivityCommandHandler> logger,
    IDistributedCache distributedCache)
: IRequestHandler<AdsClickActivityCommand>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<AdsClickActivityCommandHandler> Logger { get; } = logger;

    #endregion
    
    #region ( Helpers ) 
    public decimal CalculateCPC(decimal secondHighestBid, decimal increasePercent = 25)
    {
        var multiplier = (100 + increasePercent) / 100;
        return Math.Round(secondHighestBid * multiplier);
    }
    #endregion

    public async Task<Result> Handle(AdsClickActivityCommand request, CancellationToken cancellationToken)
    {
        #region ( Ads Click Activity Command )
        
        var result = new Result();
        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            var click = await UnitOfWork.ClickRepository.TableNoTracking.FirstOrDefaultAsync(a => a.Type.Equals(request.ClickType), cancellationToken: cancellationToken);
            if (click is null) return result.WithError(Resources.Messages.Validations.NotFoundException);

            var keyword = await UnitOfWork.KeywordRepository.TableNoTracking.SingleOrDefaultAsync(a => a.Id.Equals(request.KeywordId), cancellationToken: cancellationToken);
            if (keyword is null) return result.WithError(Resources.Messages.Validations.NotFoundException);

            
            var subscriptionClick = Mapper.Map<SubscriptionClick>(request);
            subscriptionClick.ClickedTime = DateTime.Now;
            subscriptionClick.ClickId = click.Id;
            subscriptionClick.IsDeposit = false;

            #region ( Calculate CPC )

            var jobKeywordUsersId = await UnitOfWork.JobKeywordRepository.TableNoTracking
                .Include(a => a.JobBranch)
                .Where(a => a.KeywordId == keyword.Id)
                .Select(a => new { a.JobBranch.UserId, a.JobBranchId })
                .ToListAsync(cancellationToken: cancellationToken);

            var jobOwnersAdsClickSettings = await UnitOfWork.ClickAdsSettingRepository.TableNoTracking
                .Include(a => a.User.JobBranches)
                .Where(a => jobKeywordUsersId.Select(u => u.UserId).Contains(a.UserId))
                .Where(a => a.Status)
                .OrderByDescending(a => a.MaxCostPerClick)
                .ToListAsync(cancellationToken: cancellationToken);

            if (jobOwnersAdsClickSettings.Any())
            {
                var currentJobId = jobKeywordUsersId.FirstOrDefault(a => a.JobBranchId == request.JobBranchId);
                var currentCPCIndex = jobOwnersAdsClickSettings.FindIndex(a => a.UserId.Equals(currentJobId?.UserId));

                var maxCostPerClicks = jobOwnersAdsClickSettings.Select(a => a.MaxCostPerClick).ToList();
                var distanceCostClick = maxCostPerClicks.ElementAt(currentCPCIndex + 1);

                var costPerClick = CalculateCPC(secondHighestBid: distanceCostClick, increasePercent: 20);
                subscriptionClick.CostPerClick = costPerClick;
            }

            #endregion

            await UnitOfWork.SubscriptionClickRepository.InsertAsync(subscriptionClick);
            await UnitOfWork.SaveAsync();

            await UnitOfWork.CommitTransactionAsync(cancellationToken: cancellationToken);

            #region ( Remove Cache Data )

            await DistributedCache.RemoveAsync(key: CacheKeys.JobReportQuery(Convert.ToInt32(subscriptionClick.JobId)), cancellationToken);

            #endregion

            result.WithSuccess("عملیات با موفقیت انجام شد");
            Logger.LogInformation("user activity is done!", new Hashtable(subscriptionClick.ToDictionary()));

            return result;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, "job ads click activity is error!", new Hashtable(request.ToDictionary()));

            await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);
            throw;
        }

        #endregion
    }
}