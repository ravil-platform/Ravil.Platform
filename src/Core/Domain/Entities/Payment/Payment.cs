using Domain.Entities.Subscription;
using Domain.Entities.Wallets;

namespace Domain.Entities.Payment
{
    public class Payment : BaseEntity
    {
        #region ( Properties )
        public Guid Id { get; set; }

        public double Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        #endregion

        #region ( Relations )
        public int UserSubscriptionId { get; set; }
        public virtual UserSubscription UserSubscription { get; set; }

        public int PaymentPortalId { get; set; }
        public virtual PaymentPortal PaymentPortal { get; set; }

        public int? PromotionCodeId { get; set; }
        public virtual PromotionCode PromotionCode { get; set; }

        public virtual IList<Transaction> Transactions { get; set; }
        #endregion
    }
}
