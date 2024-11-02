
namespace Application.Features.Banner.GetAllByBranchId
{
    public class GetAllBannersByBranchIdQuery : IRequest<List<BannerViewModel>>
    {
        public string JobBranchId { get; set; }
    }
}
