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
            throw new BadRequestException();
        }

        var bookMark = Mapper.Map<UserBookMark>(request);

        await UnitOfWork.UserBookMarkRepository.InsertAsync(bookMark);
        await UnitOfWork.SaveAsync();

        return Result.Ok();
    }
}