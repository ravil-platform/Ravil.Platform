namespace Domain.Entities.Blog
{
    public class BlogCategoryRel : Entity
    {
        #region (Relations)
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public int BlogCategoryId { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }
        #endregion
    }
}
