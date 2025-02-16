namespace Domain.Entities.Tag
{
    public class Tag : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string UniqueName { get; set; } = null!;

        public string IconPicture { get; set; } = null!;

        public string IconHtmlCode { get; set; } = null!;
        
        public bool Status { get; set; }

        public TagType Type { get; set; }
        #endregion

        #region (Relations)
        public virtual ICollection<JobTag> JobTags { get; set; }
        public virtual ICollection<BlogTag> BlogTags { get; set; }
        public virtual ICollection<CategoryTag> CategoryTags { get; set; }
        public virtual ICollection<JobBranchTag> JobBranchTags { get; set; }
        #endregion
    }
}