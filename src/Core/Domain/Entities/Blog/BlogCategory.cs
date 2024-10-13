namespace Domain.Entities.Blog
{
    public class BlogCategory :Entity
    {
        #region (Fields)
        public string Title { get; set; } = null!;

        public byte Sort { get; set; }

        public int ParentId { get; set; }
        #endregion

        #region (Relations)
        public virtual ICollection<BlogCategoryRel> BlogCategoryRels { get; set; }
        #endregion
    }
}
