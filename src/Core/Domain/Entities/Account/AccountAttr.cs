namespace Domain.Entities.Account
{
    public class AccountAttr : BaseEntity
    {
        #region (Relations)
        [Required]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }


        [Required]
        [ForeignKey(nameof(AttrAccount))]
        public int AttrId { get; set; }
        public virtual AttrAccount AttrAccount { get; set; }


        [Required]
        [ForeignKey(nameof(AttrAccountValue))]
        public int ValueId { get; set; }
        public virtual AttrAccountValue AttrAccountValue { get; set; }
        #endregion
    }
}
