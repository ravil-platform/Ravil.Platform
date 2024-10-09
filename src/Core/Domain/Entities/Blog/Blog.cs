namespace Domain.Entities.Blog
{
    public class Blog : BaseMetaDataEntity
    {
        #region (Fields)
        public string Route { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string SubTitle { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public string TitleListContent { get; set; } = null!;

        public short ReadingTime { get; set; }

        public string Content { get; set; } = null!;

        public string LargePicture { get; set; } = null!;

        public string SmallPicture { get; set; } = null!;

        public bool IsResizePicture { get; set; } = true;

        public int ViewCount { get; set; } = 0;

        public string AuthorName { get; set; } = null!;
        #endregion

        #region (Relations)
        public virtual ICollection<BlogTag> BlogTags { get; set; } 

        public virtual ICollection<Comment.Comment> BlogComments { get; set; }

        public virtual ICollection<BlogCategoryRel> BlogCategoryRels { get; set; }

        public virtual ICollection<UserBlogAction> BlogUserActions { get; set; }

        public virtual ICollection<UserBlogLike> BlogUserLikes { get; set; } //TODO: Optional
        #endregion
    }
}
