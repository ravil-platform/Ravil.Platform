namespace Domain.Entities.Banner
{
    public class Banner : Entity
    {
        #region ( Fields )
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int? ExpireDay { get; set; }

        public string LargePicture { get; set; } = null!;

        public string SmallPicture { get; set; } = null!;

        public int ViewCount { get; set; } = 0;

        public int ClickCount { get; set; } = 0;
        
        public byte Sort { get; set; }
        
        public string LinkPage { get; set; } = null!;
        
        public BannerType BannerType { get; set; }
        
        public BannerPictureType BannerPictureType { get; set; }

        public DateTime? ExpireDate { get; set; }
        #endregion

        #region ( Relations )
        public string JobBranchId { get; set; }
        public virtual JobBranch JobBranch { get; set; }

        public virtual ICollection<UserBannerClick> UserBannerClicks { get; set; }
        public virtual ICollection<UserBannerView> UserBannerViews { get; set; }
        #endregion
    }
}
