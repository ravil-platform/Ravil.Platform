namespace Domain.Entities.User
{
    public class ApplicationUser : IdentityUser , IEntity
    {
        #region (Fields)
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public DateTime? ConfirmationDate { get; set; }

        public string? LockoutReason { get; set; }

        public string? NationalCode { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? Avatar { get; set; }

        public GenderPerson Gender { get; set; }

        public string? OneTimeUseCode { get; set; }

        public DateTime? OneTimeUseCodeEnd { get; set; }

        public bool UserIsBlocked { get; set; }

        public DateTime BlockedDate { get; set; }

        public int ExpireTimeSpanBlock { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime UpdateDate { get; set; }

        public string? LastUpdateDateReason { get; set; }

        public DateTime LastDeleteBicycleDate { get; set; }

        public UserNameType UserNameType { get; set; } = UserNameType.PhoneNumber;
        #endregion

        #region (Relations)
        public int? StateBaseId { get; set; }
        public virtual StateBase StateBase { get; set; }

        public int? CityBaseId { get; set; }
        public virtual CityBase CityBase { get; set; }

        //public virtual Wallet Wallet { get; set; }

        public virtual ICollection<Order.Order> Orders { get; set; }
        public virtual ICollection<Comment.Comment> Comments { get; set; }
        public virtual ICollection<JobBranch> JobBranches { get; set; }
        //public virtual ICollection<Transaction.Transaction> Transactions { get; set; }

        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        public virtual ICollection<UserBookMark> UserBookMarks { get; set; }
        public virtual ICollection<UserBlogLike> UserBlogLikes { get; set; }
        public virtual ICollection<UserBannerView> UserBannerViews { get; set; }
        public virtual ICollection<UserBannerClick> UserBannerClicks { get; set; }
        #endregion
    }
}
