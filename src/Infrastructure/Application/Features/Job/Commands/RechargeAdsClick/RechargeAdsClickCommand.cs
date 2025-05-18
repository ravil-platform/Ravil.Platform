namespace Application.Features.Job.Commands.RechargeAdsClick;

public class RechargeAdsClickCommand : IRequest<RechargeAdsClickViewModel>
{
    public string UserId { get; set; } = null!;
    public int PortalId { get; set; }
    public decimal Price { get; set; }
    public decimal GiftPrice { get; set; }
}