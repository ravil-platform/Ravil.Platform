using AngleSharp.Common;
using System.Collections;
using Resources.Messages;
using ViewModels.QueriesResponseViewModel.MessageBox;

namespace Application.Features.MessageBox.Commands.ReadAllMessages;

public class ReadAllMessagesCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    Logging.Base.ILogger<ReadAllMessagesCommandHandler> logger)
    : IRequestHandler<ReadAllMessagesCommand, List<MessageBoxViewModel>>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<ReadAllMessagesCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<MessageBoxViewModel>>> Handle(ReadAllMessagesCommand request, CancellationToken cancellationToken)
    {
        #region ( Read All Messages Command )

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

        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            var businessOwnerJobId = await UnitOfWork.JobBranchRepository.TableNoTracking
                .Where(a => a.UserId == businessOwnerId).Select(a => a.JobId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var messageBoxes = await UnitOfWork.MessageBoxRepository.Table
                .Where(a => a.JobId == businessOwnerJobId && !a.IsRead)
                .ToListAsync(cancellationToken: cancellationToken);

            if (messageBoxes.Any())
            {
                await UnitOfWork.MessageBoxRepository.UpdateRangeAsync(messageBoxes);
                await UnitOfWork.SaveAsync();
            }

            await UnitOfWork.CommitTransactionAsync(cancellationToken: cancellationToken);

            var messageBoxViewModels = Mapper.Map<List<MessageBoxViewModel>>(messageBoxes);
            return messageBoxViewModels;
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