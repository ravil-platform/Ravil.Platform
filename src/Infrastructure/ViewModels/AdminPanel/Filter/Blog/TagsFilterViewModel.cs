using Domain.Entities.Tag;

namespace ViewModels.AdminPanel.Filter.Blog;

public class TagsFilterViewModel : Paging<Tag>
{
    public string? Name { get; set; }
    public TagType? TagType { get; set; }
}