
namespace Application.Features.Banner.GetAllByType
{
    public class GetAllBannersByTypeQuery : IRequest<List<BannerViewModel>>
    {
        public BannerType BannerType { get; set; }
    }
}
