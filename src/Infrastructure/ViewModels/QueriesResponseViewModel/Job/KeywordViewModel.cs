namespace ViewModels.QueriesResponseViewModel.Job
{
    public class KeywordViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool IsCategory { get; set; }
        
        #region ( Meta SEO Props )

        public string? MetaTitle { get; set; }
        public string? MetaDesc { get; set; }
        public bool IndexMeta { get; set; }
        public bool CanonicalMeta { get; set; }
        public string? MetaCanonicalUrl { get; set; }

        #endregion

        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
