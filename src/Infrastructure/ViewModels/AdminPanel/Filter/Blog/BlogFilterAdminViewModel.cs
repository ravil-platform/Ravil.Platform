namespace ViewModels.AdminPanel.Filter.Blog
{
    public class BlogFilterAdminViewModel : Paging<Domain.Entities.Blog.Blog>
    {
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }
        public bool? IsActive { get; set; }
        public bool? IndexSeo { get; set; }
        public bool? CanonicalSeo { get; set; }

        public SortBy? SortBy { get; set; }

        public bool FindAll { get; set; }
    }

    public enum SortBy
    {
        MostViewed,
        Newest,
        Oldest,
    }
}
