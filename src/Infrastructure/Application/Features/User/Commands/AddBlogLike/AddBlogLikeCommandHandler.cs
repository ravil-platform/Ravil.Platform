namespace Application.Features.User.Commands.AddBlogLike;

public class AddBlogLikeCommandHandler : IRequestHandler<AddBlogLikeCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public AddBlogLikeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddBlogLikeCommand request, CancellationToken cancellationToken)
    {
        var userBlogLike = Mapper.Map<UserBlogLike>(request);


        await UnitOfWork.UserBlogLikeRepository.InsertAsync(userBlogLike);
        await UnitOfWork.SaveAsync();

        return Result.Ok();
    }
}