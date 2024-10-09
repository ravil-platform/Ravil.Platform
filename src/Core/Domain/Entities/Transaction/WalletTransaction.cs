namespace Domain.Entities.Transaction
{
    public class WalletTransaction
    {
        #region (Fields)
        public int Id { get; set; }
        #endregion

        #region (Relations)
        [ForeignKey("WalletId")]
        public virtual Wallet Wallet { get; set; }
        [Required]
        public int WalletId { get; set; }


        public virtual Transaction Transaction { get; set; }
        public string TransactionId { get; set; }
        #endregion
    }
}