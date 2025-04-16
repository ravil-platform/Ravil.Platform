namespace Domain.Entities.Wallets
{
    public class Wallet : BaseEntity
    {
        #region ( Properties )
        public Guid Id { get; set; }

        public double Inventory { get; set; }
        #endregion

        #region ( Relations )
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual IList<WalletTransaction> WalletTransactions { get; set; }
        #endregion
    }
}