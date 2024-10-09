namespace Domain.Entities.Account
{
    public class Account : BaseEntity
    {
        #region ( Fields )
        public string Title { get; set; } = null!;

        public string Subtitle { get; set; } = null!;

        public string Content { get; set; } = null!;

        public double Price { get; set; }

        public int Discount { get; set; } = 0;

        public double DiscountedPrice { get; set; }

        public int SalesCount { get; set; } = 0;

        public bool Status { get; set; }

        public bool IsRecommended { get; set; }

        public string Picture { get; set; } = null!;

        public string IconPicture { get; set; } = null!;

        public int ExpireDay { get; set; } = 30;

        public DateTime ExpireDate { get; set; } = DateTime.Now.AddDays(30);
        #endregion

        #region ( Relations )
        public int? AccountLevelId { get; set; }
        public virtual AccountLevel? AccountLevel { get; set; }

        public int? AccountCategoryId { get; set; }
        public virtual AccountCategory? AccountCategory { get; set; }

        public virtual required ICollection<Order.Order> Orders { get; set; }
        public virtual required ICollection<AccountAttr> AccountAttrs { get; set; }
        #endregion
    }
}