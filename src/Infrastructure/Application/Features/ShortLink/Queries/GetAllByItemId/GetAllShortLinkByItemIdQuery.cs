using ViewModels.QueriesResponseViewModel.ShortLink;

namespace Application.Features.ShortLink.Queries.GetAllByItemId
{
    public class GetAllShortLinkByItemIdQuery : IRequest<List<ShortLinkViewModel>>
    {
        public int ItemId { get; set; }
    }
}
