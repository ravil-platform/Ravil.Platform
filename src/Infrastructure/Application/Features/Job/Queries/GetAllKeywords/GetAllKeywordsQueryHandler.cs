using System.Collections;
using AngleSharp.Common;
using Constants.Caching;
using Resources.Messages;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetAllKeywords;

public class GetAllKeywordsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetAllKeywordsQueryHandler> logger,
    IHttpContextAccessor httpContextAccessor,
    IDistributedCache distributedCache)
: IRequestHandler<GetAllKeywordsQuery, List<KeywordViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<GetAllKeywordsQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<KeywordViewModel>>> Handle(GetAllKeywordsQuery request, CancellationToken cancellationToken)
    {
        #region ( Get All Keywords Query )

        #region ( Validations )

        if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
        {
            return Result.Fail(Validations.BadRequestException);
        }

        #endregion

        try
        {
            var keywordsCache = await DistributedCache.GetAsync<List<KeywordViewModel>>(CacheKeys.GetAllKeywordsQuery());
            if (keywordsCache != null)
            {
                if (request.CategoryId.HasValue)
                {
                    keywordsCache = keywordsCache.Where(a => a.CategoryId == request.CategoryId.Value).ToList();
                }

                return keywordsCache;
            }
            else
            {
                var keywords = await UnitOfWork.KeywordRepository.TableNoTracking
                    .Where(a => a.IsActive)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (!keywords.Any()) return Result.Ok();

                if (request.CategoryId.HasValue)
                {
                    keywords = keywords.Where(a => a.CategoryId == request.CategoryId.Value).ToList();
                }

                var result = Mapper.Map<List<KeywordViewModel>>(keywords);

                #region ( Set Cache )

                await DistributedCache.SetCache(key: CacheKeys.GetAllKeywordsQuery(), value: result,
                    options: new DistributedCache.CacheOptions
                    {
                        ExpireSlidingCacheFromMinutes = 4 * 60,
                        AbsoluteExpirationCacheFromMinutes = 24 * 60
                    });

                #endregion

                return result;
            }
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));

            await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);
        }

        return Result.Fail(Resources.Messages.Validations.BadRequestException);

        #endregion
    }
}