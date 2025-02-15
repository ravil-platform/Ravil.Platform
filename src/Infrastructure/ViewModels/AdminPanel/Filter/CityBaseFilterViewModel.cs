using Domain.Entities.City;

namespace ViewModels.AdminPanel.Filter;

public class CityBaseFilterViewModel : Paging<CityBase>
{
    public string? Name { get; set; }
    public int? StateId { get; set; }

    public bool FindAll { get; set; }
}