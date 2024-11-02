
namespace Application.Features.Comment.Queries.GetAllAnswersByCommentId
{
    public class GetAnswersByCommentIdQuery : IRequest<List<AnswerCommentViewModel>>
    {
        public int CommentId { get; set; }
    }
}
