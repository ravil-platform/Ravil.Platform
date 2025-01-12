namespace ViewModels.AdminPanel.Filter.Blog
{
    public class BlogFilterViewModel : Paging<Domain.Entities.Blog.Blog, BlogViewModel>
    {
        public string? Title { get; set; }
        public string? Term { get; set; }
        public string? Summary { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }
        public bool? IsActive { get; set; }


        public bool FindAll { get; set; }
    }
}
