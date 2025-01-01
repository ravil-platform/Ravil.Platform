using Application.Features.Category.Queries.GetMainCategories;

namespace Application.Features.Category.Queries.GetChildCategories;

public class GetChildCategoryQuery : IRequest<List<CategoryViewModel>>
{
    public int ParentId { get; set; }
    public int NodeLevel { get; set; }
}