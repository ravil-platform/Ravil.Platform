namespace Application.Features.Job.Commands.AdsClickActivity;

public class AdsClickActivityCommand : IRequest
{
    public int SubscriptionId { get; set; }
    public string JobBranchId { get; set; } = null!;
    public string KeywordPageTitle { get; set; } = null!;
    public string KeywordPageUrl { get; set; } = null!;
    public string KeywordSlug { get; set; } = null!;
    public Guid? KeywordId { get; set; }
    public ClickType ClickType { get; set; }
    public int Position { get; set; }
}