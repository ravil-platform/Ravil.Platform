namespace ViewModels.QueriesResponseViewModel.Blog
{
    public class BlogViewModel
    {
        public string Route { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string SubTitle { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public string TitleListContent { get; set; } = null!;

        public short ReadingTime { get; set; }

        public string Content { get; set; } = null!;

        public string LargePicture { get; set; } = null!;

        public string SmallPicture { get; set; } = null!;

        public bool IsResizePicture { get; set; }

        public int ViewCount { get; set; } = 0;

        public string AuthorName { get; set; } = null!;

        public string MetaTitle { get; set; } = null!;

        public string MetaDesc { get; set; } = null!;

        public bool IndexMeta { get; set; }

        public bool CanonicalMeta { get; set; }

        public string MetaCanonicalUrl { get; set; } = null!;
    }
}
