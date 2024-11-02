
namespace Application.Features.Comment.Commands.Create;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public CreateCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }


    public async Task<Result<CommentViewModel>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = Mapper.Map<Domain.Entities.Comment.Comment>(request);

        await UnitOfWork.CommentRepository.InsertAsync(comment);
        await UnitOfWork.SaveAsync();

        var commentViewModel = Mapper.Map<CommentViewModel>(comment);

        return commentViewModel;
    }
}