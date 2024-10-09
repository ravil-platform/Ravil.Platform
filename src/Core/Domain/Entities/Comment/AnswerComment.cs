namespace Domain.Entities.Comment
{
    public class AnswerComment : BaseEntity
    {
        #region (Fields)
        public string? AdminId { get; set; }

        public bool IsAdminAnswer { get; set; } = false;

        public string UserIp { get; set; } = null!;

        public string? UserId { get; set; }

        public string? AnswerCommentTitle { get; set; }

        public string AnswerCommentText { get; set; } = null!;

        public DateTime AnswerCommentDate { get; set; } = DateTime.Now;
        public DateTime? ReviewDate { get; set; } = DateTime.Now;

        public bool IsConfirmed { get; set; } = false;

        public string? Phone { get; set; } 

        public string? Email { get; set; }

        public string? FullName { get; set; }

        public string? Avatar { get; set; } 
        #endregion

        #region (Relations)
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        #endregion
    }
}
