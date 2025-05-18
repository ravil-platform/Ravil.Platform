using System.Reflection.PortableExecutable;

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

        public string? Avatar { get; set; }

        public string UserIp { get; set; } = null!;

        public byte? Rate { get; set; }

        public int? UpVotesCount { get; set; }
        public int? DownVotesCount { get; set; }
        
        public DateTime? UpVoteLastUpdate { get; set; }
        public DateTime? DownVoteLastUpdate { get; set; }

        #endregion

        #region (Relations)
        public string? JobBranchId { get; set; }
        public virtual JobBranch JobBranch { get; set; }

        public int? BlogId { get; set; }
        public virtual Blog.Blog Blog { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<AnswerComment> AnswerComments { get; set; }

        public virtual ICollection<CommentInteraction> CommentInteractions { get; set; }
        #endregion
    }
}
