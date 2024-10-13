namespace Domain.Entities.Transaction
{
    public class Transaction : Entity<Guid>
    {
        #region (Fields)
        /// <summary>
        /// عنوان تراکنش
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// توضیحات تراکنش
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// شناسه مرجع
        /// </summary>
        public string RefCode { get; set; }

        /// <summary>
        /// شماره تراکنش
        /// </summary>
        public string TransactionNumber { get; set; }

        /// <summary>
        /// شناسه پرداخت
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// مبلغ تراکنش
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// وضعیت پرداخت تراکنش
        /// </summary>
        public bool IsPay { get; set; }

        /// <summary>
        /// تاریخ تراکنش
        /// </summary>
        public DateTime TransactionDate { get; set; }
        #endregion

        #region (Relation)
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        //public virtual Order.Order Order { get; set; }
        public Guid OrderId { get; set; }


        public virtual ICollection<WalletTransaction> WalletTransaction { get; set; }
        #endregion
    }
}