using System.Collections;
using AngleSharp.Common;
using ViewModels.QueriesResponseViewModel.MessageBox;

namespace Application.Features.MessageBox.Queries.GetAllMessageBoxByFilter;

public class GetAllMessageBoxByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetAllMessageBoxByFilterQueryHandler> logger)
    : IRequestHandler<GetAllMessageBoxByFilterQuery, List<MessageBoxViewModel>>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected Logging.Base.ILogger<GetAllMessageBoxByFilterQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<MessageBoxViewModel>>> Handle(GetAllMessageBoxByFilterQuery request, CancellationToken cancellationToken)
    {
        #region ( Get All MessageBox By Filter Query )

        try
        {
            var query = UnitOfWork.MessageBoxRepository.TableNoTracking
                .Where(a => a.IsRead == request.UnReadMessages && a.JobId == request.JobId).AsQueryable();

            var messageBoxes = await query
                .ToListAsync(cancellationToken: cancellationToken);

            var result = Mapper.Map<List<MessageBoxViewModel>>(messageBoxes);

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