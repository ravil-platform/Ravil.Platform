using Application.Features.Tag.Queries.GetAll;

namespace Application.Features.Tag.Queries.GetTagsByCategoryId
{
    public class GetTagsByCategoryIdQuery : IRequest<List<TagViewModel>>
    {
        public int CategoryId { get; set; }
    }
}
