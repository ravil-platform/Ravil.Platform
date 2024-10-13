namespace Domain.Entities.Attr
{
    public class AttrAccountValue : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }

        public string Value { get; set; }

        public int Sort { get; set; }
        #endregion

        #region (Relations)
        public int AttrAccountId { get; set; }
        public virtual required AttrAccount AttrAccount { get; set; }


        public virtual required ICollection<AccountAttr> AccountAttrs { get; set; }
        #endregion
    }
}
