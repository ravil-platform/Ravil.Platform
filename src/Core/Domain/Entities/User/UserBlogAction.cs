namespace Domain.Entities.User
{
    public class UserBlogAction : BaseEntity
    {
        #region (Fields)
        public BlogActionType BlogActionType { get; set; }

        public int ActionScore { get; set; }

        public byte? Rating { get; set; }

        public DateTime ActionDate { get; set; } = DateTime.Now;
        #endregion

        #region (Relations)
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int BlogId { get; set; }
        public virtual Blog.Blog Blog { get; set; }

        public int ActionId { get; set; }
        #endregion
    }
}
