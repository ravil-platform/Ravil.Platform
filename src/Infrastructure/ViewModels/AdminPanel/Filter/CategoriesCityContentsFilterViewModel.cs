using Domain.Entities.Category;

namespace ViewModels.AdminPanel.Filter;

public class CategoriesCityContentsFilterViewModel : Paging<CategoriesCityContent>
{
    public int? CityId { get; set; }
    public int? CategoryId { get; set; }

    public bool FindAll { get; set; }
}