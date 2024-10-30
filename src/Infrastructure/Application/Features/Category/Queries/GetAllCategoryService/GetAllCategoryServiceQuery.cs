namespace Application.Features.Category.Queries.GetAllCategoryService
{
    public class GetAllCategoryServiceQuery : IRequest<List<CategoryServiceViewModel>>
    {
        public int? CategoryId { get; set; }
        public int? ServiceId { get; set; }
    }
}
