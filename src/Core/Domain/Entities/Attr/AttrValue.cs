namespace Domain.Entities.Attr
{
    public class AttrValue : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }

        public string Value { get; set; }

        public int Sort { get; set; }
        #endregion

        #region (Relations)
        public int AttrId { get; set; }
        public virtual Attr Attr { get; set; }


        public virtual ICollection<JobBranchAttr> JobBranchAttrs { get; set; }
        #endregion
    }
}
