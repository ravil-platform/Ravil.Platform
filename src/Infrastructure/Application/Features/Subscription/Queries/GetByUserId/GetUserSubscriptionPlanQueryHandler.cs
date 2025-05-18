using AngleSharp.Common;
using System.Collections;
using Resources.Messages;
using AutoMapper.QueryableExtensions;
using ViewModels.QueriesResponseViewModel.Subscription;

namespace Application.Features.Subscription.Queries.GetByUserId;

public class GetUserSubscriptionPlanQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetUserSubscriptionPlanQueryHandler> logger)
    : IRequestHandler<GetUserSubscriptionPlanQuery, UserSubscriptionViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected Logging.Base.ILogger<GetUserSubscriptionPlanQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<UserSubscriptionViewModel>> Handle(GetUserSubscriptionPlanQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Active UserSubscription Plan Query )

        try
        {
            var userSubscriptionPlan = await UnitOfWork.UserSubscriptionRepository.TableNoTracking
                .Where(a => a.IsActive && a.IsFinally && a.UserId == request.UserId && a.EndDate.Day > DateTime.UtcNow.Day)
                .ProjectTo<UserSubscriptionViewModel>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            if (userSubscriptionPlan is null)
                return Result.Fail(Validations.NotFoundException);

            return userSubscriptionPlan;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}