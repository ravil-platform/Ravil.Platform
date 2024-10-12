namespace Domain.Entities.Account
{
    public class AccountAttr : BaseEntity
    {
        #region ( Relations )
        public int AccountId { get; set; }
        public virtual required Account Account { get; set; }

        public int AttrId { get; set; }
        public virtual required AttrAccount AttrAccount { get; set; }

        public int ValueId { get; set; }
        public virtual required AttrAccountValue AttrAccountValue { get; set; }
        #endregion
    }
}
