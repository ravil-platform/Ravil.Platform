namespace ViewModels.QueriesResponseViewModel.Banner
{
    public class BannerViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int? ExpireDay { get; set; }

        public string LargePicture { get; set; }

        public string SmallPicture { get; set; }

        public int ViewCount { get; set; } = 0;

        public int ClickCount { get; set; } = 0;

        public byte Sort { get; set; }

        public string LinkPage { get; set; }

        public BannerType BannerType { get; set; }

        public BannerPictureType BannerPictureType { get; set; }

        public DateTime? ExpireDate { get; set; }

        public string JobBranchId { get; set; }
    }
}
