namespace Domain.Entities.Order
{
    public class Order : BaseEntity<Guid>
    {
        #region (Fields)
        public string OrderNumber { get; set; } = null!;

        public double Price { get; set; }

        public int Discount { get; set; }

        public double DiscountAmount { get; set; }

        public double? PaymentAmount { get; set; }

        public int ExpireDay { get; set; } = 30;

        public DateTime ExpireDate { get; set; } = DateTime.Now.AddDays(30);

        public OrderStatus Status { get; set; } = OrderStatus.Initial;

        public bool IsActiveAccount { get; set; } = false;

        public string AdditionalInfo { get; set; } = null!; //OrderAdditionalInfoVM

        public string? AdminId { get; set; }
        public string? AdminName { get; set; }
        public string? CookieValue { get; set; }
        #endregion

        #region (Relations)
        public string JobId { get; set; } = null!;


        public int AccountId { get; set; }
        public virtual Account.Account Account { get; set; }


        public string JobBranchId { get; set; }
        public virtual JobBranch JobBranch { get; set; }


        public int? PaymentPortalId { get; set; }
        public virtual PaymentPortal.PaymentPortal PaymentPortal { get; set; }


        public int? PromotionCodeId { get; set; }
        public virtual PromotionCode PromotionCode { get; set; }


        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        public virtual ICollection<Transaction.Transaction> Transactions { get; set; }
        #endregion
    }
}