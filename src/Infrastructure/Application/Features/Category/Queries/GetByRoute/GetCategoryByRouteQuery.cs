namespace Application.Features.Category.Queries.GetByRoute
{
    public class GetCategoryByRouteQuery : IRequest<CategoryViewModel>
    {
        public string Route { get; set; }
        public int CityId { get; set; }
    }
}
