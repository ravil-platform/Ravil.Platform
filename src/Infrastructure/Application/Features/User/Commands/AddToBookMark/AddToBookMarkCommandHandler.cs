namespace Application.Features.User.Commands.AddToBookMark;

public class AddToBookMarkCommandHandler : IRequestHandler<AddToBookMarkCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public AddToBookMarkCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddToBookMarkCommand request, CancellationToken cancellationToken)
    {
        if (request.JobBranchId is null && request.BlogId is null)
        {
            return Result.Fail(Resources.Messages.Validations.BadRequestException);
        }

        var bookMark = Mapper.Map<UserBookMark>(request);
        if (bookMark.UserBookMarkType == UserBookMarkType.JobBranch)
        {
            var existUserJobBookMark = await UnitOfWork.UserBookMarkRepository.TableNoTracking
                .Where(a => a.UserBookMarkType == UserBookMarkType.JobBranch)
                .AnyAsync(a => a.UserId == request.UserId && a.JobBranchId == request.JobBranchId, cancellationToken: cancellationToken);

            if (existUserJobBookMark)
                return Result.Fail(Resources.Messages.Validations.NotFoundException);
        }
        else
        {
            var existUserBlogBookMark = await UnitOfWork.UserBookMarkRepository.TableNoTracking
                .Where(a => a.UserBookMarkType == UserBookMarkType.Blog)
                .AnyAsync(a => a.UserId == request.UserId && a.BlogId == request.BlogId, cancellationToken: cancellationToken);

            if (existUserBlogBookMark)
                return Result.Fail(Resources.Messages.Validations.NotFoundException);
        }

        await UnitOfWork.UserBookMarkRepository.InsertAsync(bookMark);
        await UnitOfWork.SaveAsync();

        return Result.Ok();
    }
}