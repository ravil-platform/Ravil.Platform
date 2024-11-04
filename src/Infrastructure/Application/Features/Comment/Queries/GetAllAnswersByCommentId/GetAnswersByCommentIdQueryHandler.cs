namespace Application.Features.Comment.Queries.GetAllAnswersByCommentId;

public class GetAnswersByCommentIdQueryHandler : IRequestHandler<GetAnswersByCommentIdQuery, List<AnswerCommentViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAnswersByCommentIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<AnswerCommentViewModel>>> Handle(GetAnswersByCommentIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.AnswerCommentRepository.GetAllAsync(c => c.CommentId == request.CommentId);

        var answersViewModel = Mapper.Map<List<AnswerCommentViewModel>>(result);

        return answersViewModel;
    }
}