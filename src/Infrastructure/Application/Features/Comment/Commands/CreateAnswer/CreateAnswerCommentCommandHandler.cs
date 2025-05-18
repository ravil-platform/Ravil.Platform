
using AngleSharp.Common;
using System.Collections;
using Resources.Messages;

namespace Application.Features.Comment.Commands.CreateAnswer;

public class CreateAnswerCommentCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor,
    Logging.Base.ILogger<CreateAnswerCommentCommandHandler> logger) 
    : IRequestHandler<CreateAnswerCommentCommand, AnswerCommentViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<CreateAnswerCommentCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<AnswerCommentViewModel>> Handle(CreateAnswerCommentCommand request, CancellationToken cancellationToken)
    {
        #region ( Create Answer Comment Command )

        if (HttpContextAccessor.HttpContext?.Connection.RemoteIpAddress is null)
        {
            return Result.Fail(Resources.Messages.Validations.NotFoundException);
        }

        #region ( Check Answer By Job Owner )

        if (!string.IsNullOrWhiteSpace(request.UserId))
        {
            var currentComment = await UnitOfWork.CommentRepository.GetByIdAsync(request.CommentId);
            if (currentComment is not null && currentComment.CommentType == CommentTypes.JobBranch && !string.IsNullOrWhiteSpace(currentComment.JobBranchId))
            {
                var answerByJobOwner = await UnitOfWork.JobBranchRepository.TableNoTracking
                    .AnyAsync(a => a.Id == currentComment.JobBranchId && a.UserId == request.UserId, cancellationToken: cancellationToken);

                if (!answerByJobOwner)
                    return Result.Fail(Validations.NotFoundException);
            }
        }

        #endregion

        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            var answerComment = Mapper.Map<AnswerComment>(request);
            answerComment.UserIp = HttpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            answerComment.AnswerCommentDate = DateTime.Now;
            answerComment.CreateDate = DateTime.Now;

            await UnitOfWork.AnswerCommentRepository.InsertAsync(answerComment);
            await UnitOfWork.SaveAsync();

            var comment = Mapper.Map<AnswerCommentViewModel>(answerComment);

            return comment;
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