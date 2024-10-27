using Application.Features.Category.Queries.GetAll;
using Application.Features.Category.Queries.GetAllByFilter;
using Application.Features.Category.Queries.GetAllByParentId;
using Application.Features.Category.Queries.GetAllCategoryService;
using Application.Features.Category.Queries.GetByRoute;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : GenericBaseController<CategoryController>
    {
        public CategoryController(IMediator mediator, Logging.Base.ILogger<CategoryController> logger) : base(mediator, logger)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll(GetAllCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllByParentId(GetAllCategoriesByParentIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllByFilter(GetAllCategoriesByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> GetByRoute(GetCategoryByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetCategoryServices(GetAllCategoryServiceQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
