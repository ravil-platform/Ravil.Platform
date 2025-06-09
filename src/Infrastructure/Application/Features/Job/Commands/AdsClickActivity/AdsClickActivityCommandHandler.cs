using Constants.Caching;
using AngleSharp.Common;
using System.Collections;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Commands.AdsClickActivity;

public class AdsClickActivityCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor, IDistributedCache distributedCache, 
    Logging.Base.ILogger<AdsClickActivityCommandHandler> logger)
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
            
            var subscriptionClick = Mapper.Map<SubscriptionClick>(request);
            subscriptionClick.ClickedTime = DateTime.UtcNow;
            subscriptionClick.ClickId = click.Id;
            subscriptionClick.IsDeposit = false;

            #region ( Calculate CPC )

            if (request.KeywordId.HasValue)
            {
                var keyword = await UnitOfWork.KeywordRepository.TableNoTracking.SingleOrDefaultAsync(a => a.Id.Equals(request.KeywordId), cancellationToken: cancellationToken);
                if (keyword is null) return result.WithError(Resources.Messages.Validations.NotFoundException);

                var jobKeywordUsersId = await UnitOfWork.JobKeywordRepository.TableNoTracking
                    .Include(a => a.JobBranch)
                    .Where(a => a.KeywordId == keyword.Id)
                    .Select(a => new { a.JobBranch.UserId, a.JobBranchId, a.JobBranch.JobId })
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
                    var currentCpcIndex = jobOwnersAdsClickSettings.FindIndex(a => a.UserId.Equals(currentJobId?.UserId));

                    var maxCostPerClicks = jobOwnersAdsClickSettings.Select(a => a.MaxCostPerClick).ToList();
                    var distanceCostClick = maxCostPerClicks.ElementAt(currentCpcIndex + 1);

                    var costPerClick = CalculateCPC(secondHighestBid: distanceCostClick, increasePercent: 20);
                    subscriptionClick.CostPerClick = costPerClick;
                    subscriptionClick.JobId = currentJobId!.JobId;
                }
                else
                {
                    var jobOwner = await UnitOfWork.JobBranchRepository.TableNoTracking.SingleOrDefaultAsync(a => a.Id == request.JobBranchId, cancellationToken: cancellationToken);
                    if (jobOwner is null) return result.WithError(Resources.Messages.Validations.NotFoundException);

                    subscriptionClick.CostPerClick = click.CostPerClick;
                    subscriptionClick.JobId = jobOwner.JobId;
                }
            }
            else
            {
                var jobOwner = await UnitOfWork.JobBranchRepository.TableNoTracking.SingleOrDefaultAsync(a => a.Id == request.JobBranchId, cancellationToken: cancellationToken);
                if (jobOwner is null) return result.WithError(Resources.Messages.Validations.NotFoundException);
                
                var jobOwnerAdsClickSetting = await UnitOfWork.ClickAdsSettingRepository.TableNoTracking
                    .Where(a => a.UserId == jobOwner.UserId && a.Status)
                    .SingleOrDefaultAsync(cancellationToken: cancellationToken);

                if (jobOwnerAdsClickSetting is null)
                    return result.WithError(Resources.Messages.Validations.NotFoundException);

                var costPerClick = jobOwnerAdsClickSetting.MaxCostPerClick;
                subscriptionClick.CostPerClick = costPerClick;
                subscriptionClick.JobId = jobOwner.JobId;
            }

            #endregion

            await UnitOfWork.SubscriptionClickRepository.InsertAsync(subscriptionClick);
            await UnitOfWork.SaveAsync();

            await UnitOfWork.CommitTransactionAsync(cancellationToken: cancellationToken);

            #region ( Remove Cache Data )

            await DistributedCache.RemoveAsync(key: CacheKeys.JobReportQuery(Convert.ToInt32(subscriptionClick.JobId)), cancellationToken);

            #endregion

            result.WithSuccess(Resources.Messages.Successes.ActionIsSuccessfully);
            Logger.LogInformation(Resources.Messages.Successes.ActionIsSuccessfully, new Hashtable(subscriptionClick.ToDictionary()));

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