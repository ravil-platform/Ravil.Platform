using Domain.Entities.City;

namespace ViewModels.AdminPanel.Filter;

public class CityFilterViewModel : Paging<Domain.Entities.City.City>
{
    public string? SubTitle { get; set; }
    public bool FindAll { get; set; }
}