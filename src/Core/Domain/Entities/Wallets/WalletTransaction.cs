namespace Domain.Entities.Wallets
{
    public class WalletTransaction : BaseEntity
    {
        #region ( Properties )
        public Guid Id { get; set; }

        public bool IsConfirmed { get; set; }

        public double Amount { get; set; }

        public WalletTransactionType TransactionType { get; set; }

        public DateTime CreateDate { get; set; }
        #endregion 

        #region ( Relations )
        public Guid WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }

        public Guid TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
        #endregion
    }
}
