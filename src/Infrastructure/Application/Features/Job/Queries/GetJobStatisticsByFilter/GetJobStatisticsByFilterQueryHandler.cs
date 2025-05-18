using System.Collections;
using AngleSharp.Common;
using AutoMapper.QueryableExtensions;
using Resources.Messages;

namespace Application.Features.Job.Queries.GetJobStatisticsByFilter;

public class GetJobStatisticsByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetJobStatisticsByFilterQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<GetJobStatisticsByFilterQuery, List<JobStatisticsViewModel>>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<GetJobStatisticsByFilterQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<JobStatisticsViewModel>>> Handle(GetJobStatisticsByFilterQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Job Statistics By Filter Query )

        var result = new Result<List<JobStatisticsViewModel>>();

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
            
            var query = UnitOfWork.JobInfoRepository.TableNoTracking
                .Where(a => a.JobId == request.JobId)
                .AsQueryable();

            if (request is { FromDate: not null, ToDate: not null })
            {
                var fromDate = DateTimeOffset.FromUnixTimeSeconds(request.FromDate.Value);
                var toDate = DateTimeOffset.FromUnixTimeSeconds(request.ToDate.Value);

                query = query.Where(a => a.CreateAt.Day >= fromDate.Day && a.CreateAt.Day <= toDate.Day);
            }
            else
            {
                query = query.Where(a => a.CreateAt.Day <= DateTime.UtcNow.Day && a.CreateAt.Day >= DateTime.UtcNow.AddDays(-14).Day);
            }

            var jobStatistics = await query.OrderBy(a => a.CreateAt)
                .ProjectTo<JobStatisticsViewModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            result.WithValue(jobStatistics);
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