namespace Application.Features.Category.Queries.GetRelatedRegion
{
    public class GetRelatedRegionQuery : IRequest<List<RelatedCategorySeo>>
    {
        public int CurrentCityId { get; set; }
    }
}
