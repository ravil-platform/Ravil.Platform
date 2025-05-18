using Domain.Entities.Wallets;
using System.Security.Cryptography;
using ViewModels.QueriesResponseViewModel.Payments;

namespace Application.Features.Job.Commands.RechargeAdsClickVerification;

public class RechargeAdsClickVerificationCommand : IRequest<RechargeAdsClickVerificationViewModel>
{
    public int PortalId { get; set; }
    public Guid WalletTransactionId { get; set; }
    public string Status { get; set; } = null!;
    public string Authority { get; set; } = null!;
}