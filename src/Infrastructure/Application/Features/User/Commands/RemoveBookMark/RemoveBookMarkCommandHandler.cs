namespace Application.Features.User.Commands.RemoveBookMark;

public class RemoveBookMarkCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveBookMarkCommand>
{
    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<Result> Handle(RemoveBookMarkCommand request, CancellationToken cancellationToken)
    {
        #region ( Remove BookMark Command )

        var bookMark = await UnitOfWork.UserBookMarkRepository.GetByPredicate(u => u.UserId == request.UserId && u.JobBranchId == request.JobBranchId);

        if (bookMark is null)
        {
            return Result.Fail(Resources.Messages.Validations.NotFoundException);
        }

        await UnitOfWork.UserBookMarkRepository.DeleteAsync(bookMark);
        await UnitOfWork.SaveAsync();

        return Result.Ok();

        #endregion
    }
}