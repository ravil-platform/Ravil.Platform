namespace Domain.Entities.Wallets
{
    public class Transaction : BaseEntity
    {
        #region ( Properties )
        public Guid Id { get; set; }

        public string Number { get; set; }
        public string? Amount { get; set; }

        public string? RefId { get; set; }
        public string? AuthCode { get; set; }
        public string? TrackingCode { get; set; }

        public DateTime TransactionDate { get; set; }

        public TransactionStatus Status { get; set; }
        #endregion

        #region ( Relations )
        public Guid? PaymentId { get; set; }
        public virtual Payment.Payment Payment { get; set; }

        public virtual IList<WalletTransaction> WalletTransactions { get; set; }
        #endregion 
    }
}
