using Domain.Entities.Comment;
using ViewModels.QueriesResponseViewModel.Comment;

namespace Application.Features.Comment.Commands.CreateAnswer;

public class CreateAnswerCommentCommandHandler : IRequestHandler<CreateAnswerCommentCommand, AnswerCommentViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public CreateAnswerCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }
    public async Task<Result<AnswerCommentViewModel>> Handle(CreateAnswerCommentCommand request, CancellationToken cancellationToken)
    {
        var answerComment = Mapper.Map<AnswerComment>(request);

        await UnitOfWork.AnswerCommentRepository.InsertAsync(answerComment);
        await UnitOfWork.SaveAsync();

        var comment = Mapper.Map<AnswerCommentViewModel>(answerComment);

        return comment;
    }
}