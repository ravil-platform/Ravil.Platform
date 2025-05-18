using System.Collections;
using AngleSharp.Common;
using AutoMapper.QueryableExtensions;
using ViewModels.QueriesResponseViewModel.Subscription;

namespace Application.Features.Subscription.Queries.GetAll;

public class GetAllSubscriptionPlanQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetAllSubscriptionPlanQueryHandler> logger)
    : IRequestHandler<GetAllSubscriptionPlanQuery, List<SubscriptionViewModel>>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected Logging.Base.ILogger<GetAllSubscriptionPlanQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<SubscriptionViewModel>>> Handle(GetAllSubscriptionPlanQuery request, CancellationToken cancellationToken)
    {
        #region ( Get All Subscription Plans Query )

        try
        {
            var query = UnitOfWork.SubscriptionRepository.TableNoTracking
                .Where(a => a.IsActive).AsQueryable();

            if (request.DurationType.HasValue)
            {
                query = query.Where(a => a.DurationType == request.DurationType);
            }

            if (request.SubscriptionType.HasValue)
            {
                query = query.Where(a => a.Type == request.SubscriptionType);
            }
            
            var subscriptionPlans = await query
                .ProjectTo<SubscriptionViewModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return subscriptionPlans;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}