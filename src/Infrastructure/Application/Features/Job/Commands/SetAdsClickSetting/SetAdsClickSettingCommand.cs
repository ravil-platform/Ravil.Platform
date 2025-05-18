using ViewModels.QueriesResponseViewModel.Subscription;

namespace Application.Features.Job.Commands.SetAdsClickSetting;

public class SetAdsClickSettingCommand : IRequest<ClickAdsSettingViewModel>
{
    public bool Status { get; set; }
    public int AdDisplayRange { get; set; }
    public decimal MaxCostPerClick { get; set; }
    public string UserId { get; set; } = null!;
}