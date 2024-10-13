namespace Domain.Entities.Transaction
{
    public class WalletTransaction : IEntity
    {
        #region (Fields)
        public int Id { get; set; }
        #endregion

        #region (Relations)
        [ForeignKey("WalletId")]
    //    public virtual Wallet Wallet { get; set; }
        [Required]
        public int WalletId { get; set; }


    //    public virtual Transaction Transaction { get; set; }
        public Guid TransactionId { get; set; }
        #endregion
    }
}