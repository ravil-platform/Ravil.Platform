namespace Domain.Entities.Transaction
{
    public class Wallet : BaseEntity
    {
        #region (Fields)
        /// <summary>
        /// موجودی کیف پول
        /// </summary>
        public double Inventory { get; set; }
        #endregion

        #region (Relation)
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<WalletTransaction> WalletTransaction { get; set; }
        #endregion
    }
}