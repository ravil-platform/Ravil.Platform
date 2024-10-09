namespace Domain.Entities.Banner
{
    public class Banner : BaseEntity
    {
        #region (Fields)
        public BannerType BannerType { get; set; }

        public BannerPictureType BannerPictureType { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int? ExpireDay { get; set; }

        public DateTime? ExpireDate { get; set; }

        public string LargePicture { get; set; } = null!;

        public string SmallPicture { get; set; } = null!;

        public int ViewCount { get; set; } = 0;

        public int ClickCount { get; set; } = 0;

        public byte Sort { get; set; }

        public string LinkPage { get; set; } = null!;
        #endregion

        #region (Relations)
        public string JobBranchId { get; set; }
        public virtual JobBranch JobBranch { get; set; }


        public virtual ICollection<UserBannerClick> UserBannerClicks { get; set; }


        public virtual ICollection<UserBannerView> UserBannerViews { get; set; }
        #endregion
    }

    #region (Enums)
    public enum BannerType
    {
        [Display(Name = "وبلاگ")]
        Blog,
        [Display(Name = "کسب و کار")]
        JobBranch,
        [Display(Name = "ویژه")]
        Special
    }

    public enum BannerPictureType
    {
        [Display(Name = "مربع")]
        Square,
        [Display(Name = "مستطیل")]
        Rectangle
    }
    #endregion
}
