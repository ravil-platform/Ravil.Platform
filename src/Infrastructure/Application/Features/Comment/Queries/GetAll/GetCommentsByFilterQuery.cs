namespace Application.Features.Comment.Queries.GetAll
{
    public class GetCommentsByFilterQuery : IRequest<List<CommentViewModel>>
    {
        public CommentTypes? CommentType { get; set; }

        public string? JobBranchId { get; set; }

        public int? BlogId { get; set; }

        public string? UserId { get; set; }
        
        public string? BusinessOwnerId { get; set; }

        public bool? IsConfirmed { get; set; }
        
        public bool? HasAnswered { get; set; }

        public int? Take { get; set; }
    }
}
