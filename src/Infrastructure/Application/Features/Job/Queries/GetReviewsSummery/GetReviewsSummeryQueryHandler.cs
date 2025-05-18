using System.Collections;
using AngleSharp.Common;
using Resources.Messages;
using ViewModels.QueriesResponseViewModel.Analytics;

namespace Application.Features.Job.Queries.GetReviewsSummery;

public class GetReviewsSummeryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetReviewsSummeryQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<GetReviewsSummeryQuery, ReviewsSummeryViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<GetReviewsSummeryQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<ReviewsSummeryViewModel>> Handle(GetReviewsSummeryQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Reviews Summery Query )

        var result = new Result<ReviewsSummeryViewModel>();

        try
        {
            #region ( Validations )

            if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
            {
                return Result.Fail(Validations.BadRequestException);
            }

            var businessOwnerId = UserManager.GetUserId(HttpContext!.User);
            var businessOwner = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                .SingleOrDefaultAsync(a => a.Id.Equals(businessOwnerId), cancellationToken: cancellationToken);

            if (businessOwner is null)
                return Result.Fail(Validations.BadRequestException);

            #endregion

            var commentReviews = await UnitOfWork.CommentRepository.TableNoTracking
                .Where(a => a.JobBranchId == request.JobBranchId && a.Rate > 0)
                .ToListAsync(cancellationToken: cancellationToken);
            
            var reviewsSummery = new ReviewsSummeryViewModel();
            reviewsSummery.NewCount = commentReviews.Count(a => !a.IsConfirmed);
            reviewsSummery.AverageScore = $"{commentReviews.Sum(a => a.Rate) / commentReviews.Count}";


            result.WithValue(reviewsSummery);
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