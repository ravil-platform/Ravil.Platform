using Domain.Entities.RedirectionUrl;
namespace ViewModels.AdminPanel.Filter;

public class RedirectionUrlFilterViewModel : Paging<Domain.Entities.RedirectionUrl.RedirectionUrl>
{
    public string? LatestUrl { get; set; }
    public string? DestinationUrl { get; set; }
    public RedirectionTypes? RedirectionType { get; set; }
    public bool? Status { get; set; }

    public bool FindAll { get; set; }
}