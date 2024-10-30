using ViewModels.QueriesResponseViewModel.Comment;

namespace Application.Features.Comment.Commands.CreateAnswer
{
    public class CreateAnswerCommentCommand : IRequest<AnswerCommentViewModel>
    {
        public bool IsAdminAnswer { get; set; }

        public string UserIp { get; set; }

        public string? UserId { get; set; }

        public string? AnswerCommentTitle { get; set; }

        public string AnswerCommentText { get; set; }

        public bool IsConfirmed { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? FullName { get; set; }

        public string? Avatar { get; set; }

        public int CommentId { get; set; }
    }
}
