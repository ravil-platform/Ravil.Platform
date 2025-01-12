using Domain.Entities.Blog;

namespace ViewModels.AdminPanel.Filter.Blog;

public class BlogCategoryFilterViewModel : Paging<BlogCategory>
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Slug { get; set; }
    public bool? IsActive { get; set; }

    public bool FindAll { get; set; }
}

