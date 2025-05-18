namespace Application.Features.Comment.Queries.GetAllAnswersByCommentId;

public class GetAnswersByCommentIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<GetAnswersByCommentIdQuery, List<AnswerCommentViewModel>>
{
    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<Result<List<AnswerCommentViewModel>>> Handle(GetAnswersByCommentIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.AnswerCommentRepository.GetAllAsync(c => c.CommentId == request.CommentId);

        var answersViewModel = Mapper.Map<List<AnswerCommentViewModel>>(result);

        return answersViewModel;
    }
}