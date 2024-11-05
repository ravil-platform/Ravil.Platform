namespace Application.Features.User.Commands.RemoveBookMark;

public class RemoveBookMarkCommandHandler : IRequestHandler<RemoveBookMarkCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public RemoveBookMarkCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveBookMarkCommand request, CancellationToken cancellationToken)
    {
        var bookMark = await UnitOfWork.UserBookMarkRepository.GetByPredicate(u => u.Id == request.Id);

        if (bookMark is null)
        {
            throw new NotFoundException();
        }

        await UnitOfWork.UserBookMarkRepository.DeleteAsync(bookMark);
        await UnitOfWork.SaveAsync();

        return Result.Ok();
    }
}