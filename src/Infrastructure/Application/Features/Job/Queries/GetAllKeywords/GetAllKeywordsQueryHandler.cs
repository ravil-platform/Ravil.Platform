using System.Collections;
using AngleSharp.Common;
using Resources.Messages;

namespace Application.Features.Job.Queries.GetAllKeywords;

public class GetAllKeywordsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetAllKeywordsQueryHandler> logger,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<GetAllKeywordsQuery, List<KeywordViewModel>>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
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
            var query = UnitOfWork.KeywordRepository.TableNoTracking
                //.Include(a => a.Category)
                .Where(a => a.IsActive)
                .AsQueryable();

            if (request.CategoryId.HasValue)
            {
                query = query.Where(a => a.CategoryId == request.CategoryId.Value);
            }
            
            var keywords = await query
                .ToListAsync(cancellationToken: cancellationToken);

            var result = Mapper.Map<List<KeywordViewModel>>(keywords);

            return result;
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