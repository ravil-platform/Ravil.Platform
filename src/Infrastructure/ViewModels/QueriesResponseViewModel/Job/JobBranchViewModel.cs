namespace ViewModels.QueriesResponseViewModel.Job
{
    public class JobBranchViewModel
    {
        public string Id { get; set; }
        public int JobId { get; set; }

        public string? Route { get; set; } = null!;
        public string? Title { get; set; } = null!;
        public string? HeadingTitle { get; set; }
        public string Description { get; set; } = null!;
        public string? BranchContent { get; set; }
        public string? BranchVideo { get; set; }
        public string? LargePicture { get; set; }
        public string? SmallPicture { get; set; }

        public string? MapUrl { get; set; }
        
        public bool IsOffer { get; set; }
        public bool IsAds { get; set; }
        public bool IsResizePicture { get; set; } = false;
        public JobTimeWorkType JobTimeWorkType { get; set; }
        public string? UserId { get; set; }
        public string? AddressId { get; set; }

        #region ( Meta SEO Props )

        public string? MetaTitle { get; set; }
        public string? MetaDesc { get; set; }
        public bool IndexMeta { get; set; }
        public bool CanonicalMeta { get; set; }
        public string? MetaCanonicalUrl { get; set; }

        #endregion

        public JobInfoViewModel JobInfo { get; set; }
        public AddressViewModel Address { get; set; }
        public List<CategoryListViewModel> Categories { get; set; }
        public List<JobTimeWorkViewModel> TimeWorks { get; set; }
        public List<KeywordViewModel> Keywords { get; set; }
        public List<JobBranchGalleryViewModel> Galleries { get; set; }
    }
}
