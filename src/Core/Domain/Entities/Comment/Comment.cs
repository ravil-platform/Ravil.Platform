namespace Domain.Entities.Comment
{
    public class Comment : Entity
    {
        #region (Fields)
        public CommentTypes CommentType { get; set; }

        public string CommentText { get; set; } = null!;

        public bool IsConfirmed { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;  

        public string FullName { get; set; } = null!;

        public string Avatar { get; set; } = null!;

        public string UserIp { get; set; } = null!;
        #endregion

        #region (Relations)
        public string? JobBranchId { get; set; }
        public JobBranch JobBranch { get; set; }

        public int? BlogId { get; set; }
        public Blog.Blog Blog { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<AnswerComment> AnswerComments { get; set; }
        #endregion
    }
}
