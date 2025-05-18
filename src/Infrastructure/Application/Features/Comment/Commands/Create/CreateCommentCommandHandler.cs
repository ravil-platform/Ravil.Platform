
using AngleSharp.Common;
using Application.Features.Job.Commands.AdsClickActivity;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using Resources.Messages;

namespace Application.Features.Comment.Commands.Create;

public class CreateCommentCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    Logging.Base.ILogger<CreateCommentCommandHandler> logger)
    : IRequestHandler<CreateCommentCommand, CommentViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<CreateCommentCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<CommentViewModel>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        #region ( Create Comment Command )

        #region ( Validations )

        if (HttpContextAccessor.HttpContext?.Connection.RemoteIpAddress is null)
        {
            return Result.Fail(Validations.NotFoundException);
        }

        if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
        {
            return Result.Fail(Validations.BadRequestException);
        }

        var currentUser = await UnitOfWork.ApplicationUserRepository.TableNoTracking
            .SingleOrDefaultAsync(a => a.Id.Equals(request.UserId), cancellationToken: cancellationToken);

        if (currentUser is null)
            return Result.Fail(Validations.BadRequestException);

        #endregion

        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            var comment = Mapper.Map<Domain.Entities.Comment.Comment>(request);

            comment.UserIp = HttpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            comment.Avatar = string.Format("{0}/{1}", Paths.UserServer, currentUser.Avatar);
            comment.Phone = currentUser.UserName ?? currentUser.Phone ?? string.Empty;
            comment.FullName = $"{currentUser.Firstname} {currentUser.Lastname}";
            comment.Email = currentUser.Email ?? string.Empty;
            comment.CreateDate = DateTime.Now;

            await UnitOfWork.CommentRepository.InsertAsync(comment);
            await UnitOfWork.SaveAsync();

            var commentViewModel = Mapper.Map<CommentViewModel>(comment);

            return commentViewModel;
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