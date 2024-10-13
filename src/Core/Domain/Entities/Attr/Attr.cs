namespace Domain.Entities.Attr
{
    public class Attr : Entity
    {
        #region (Fields)
        public string Title { get; set; }

        public AttributeType AttrType { get; set; }

        public bool Filter { get; set; }

        public bool ShowInPage { get; set; }

        public short Sort { get; set; }

        public string IconPicture { get; set; } = null!;

        public string IconHtmlCode { get; set; } = null!;
        #endregion

        #region (Relations)
        public int? AttrCategoryId { get; set; }
        public virtual AttrCategory AttrCategory { get; set; }

        public int CategoryId { get; set; }
        public virtual Category.Category Category { get; set; }

        public virtual ICollection<JobBranchAttr> AttrJobBranches { get; set; }
        public virtual ICollection<AttrValue> AttrValues { get; set; }
        #endregion
    }
}
