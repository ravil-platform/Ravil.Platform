namespace ViewModels.AdminPanel.Filter;

public class MainSliderFilterViewModel : Paging<Domain.Entities.MainSlider.MainSlider>
{
    public string? Title { get; set; }
    public string? LinkPage { get; set; }

    public int? StateId { get; set; }
    public int? CityId { get; set; }

    public bool FindAll { get; set; }
}