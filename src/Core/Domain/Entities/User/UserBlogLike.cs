namespace Domain.Entities.User
{
    public class UserBlogLike : IEntity
    {
        #region (Fields)
        public int Id { get; set; }

        public DateTime LikeTimeDate { get; set; } = DateTime.Now;
        #endregion

        #region (Relations)
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int BlogId { get; set; }
        public virtual Blog.Blog Blog { get; set; }
        #endregion
    }
}