using Domain.Entities.Category;

namespace ViewModels.AdminPanel.Filter;

public class RelatedCategorySeoFilterViewModel : Paging<RelatedCategorySeo>
{
    public int? CityId { get; set; }

    public bool FindAll { get; set; }
}