namespace ViewModels.AdminPanel.Filter;

public class CategoriesFilterViewModel : Paging<Domain.Entities.Category.Category>
{
    public int? ParentId { get; set; } = 0;
    public string? Name { get; set; }
    public string? Route { get; set; }
    public short? NodeLevel { get; set; } = 1;
    public bool? IsActive { get; set; }
    public string? PageContent { get; set; }

    public bool FindAll { get; set; }
}