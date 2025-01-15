namespace ViewModels.AdminPanel.Filter;

public class BannerFilterViewModel : Paging<Domain.Entities.Banner.Banner>
{
    public bool FindAll { get; set; }
}