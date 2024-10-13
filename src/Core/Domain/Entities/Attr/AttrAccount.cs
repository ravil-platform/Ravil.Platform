namespace Domain.Entities.Attr
{
    public class AttrAccount : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public AttributeType AttrType { get; set; } = AttributeType.Account;

        public short Sort { get; set; }

        public string IconPicture { get; set; } = null!;
        
        public string IconHtmlCode { get; set; } = null!;
        #endregion

        #region (Relations)
        public int? AttrCategoryId { get; set; }

        public virtual AttrCategory AttrCategory { get; set; }

    
        public virtual ICollection<AttrAccountValue> AttrAccountValues { get; set; }


        public virtual ICollection<AccountAttr> AttrAccounts { get; set; }
        #endregion
    }
}
