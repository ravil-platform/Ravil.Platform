namespace Domain.Entities.Blog;

public class BlogTag : Entity
{
    #region (Relations)
    public int BlogId { get; set; }
    public virtual Blog Blog { get; set; }

    public int TagId { get; set; }
    public virtual Tag.Tag Tag { get; set; }
    #endregion
}

