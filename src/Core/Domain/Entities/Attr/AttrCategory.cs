namespace Domain.Entities.Attr
{
    public class AttrCategory : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }

        public string Title { get; set; }

        public string IconPicture { get; set; }

        public bool Status { get; set; }

        public short Sort { get; set; }
        #endregion

        #region (Relations)
        public virtual ICollection<Attr> Attributes { get; set; }
        public virtual ICollection<AttrAccount> AttributeAccounts { get; set; }
        #endregion
    }
}
