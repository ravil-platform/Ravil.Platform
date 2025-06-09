namespace ViewModels.QueriesResponseViewModel.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        
        public Guid? KeywordId { get; set; }

        public CategoryBusinessType Type { get; set; }

        public string Name { get; set; } = null!;

        public string Route { get; set; } = null!;

        public int ParentId { get; set; }

        public short NodeLevel { get; set; }

        public string HeadingTitle { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public bool IsLastNode { get; set; }


        public string Picture { get; set; } = null!;

        public string IconPicture { get; set; } = null!;

        public int Sort { get; set; }

        public string PageContent { get; set; } = null!;

        #region ( Meta SEO Props )

        public string? MetaTitle { get; set; }
        public string? MetaDesc { get; set; }
        public bool IndexMeta { get; set; }
        public bool CanonicalMeta { get; set; }
        public string? MetaCanonicalUrl { get; set; }

        #endregion
    }
}
