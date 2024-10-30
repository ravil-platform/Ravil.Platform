using ViewModels.Filter.Category;
using ViewModels.QueriesResponseViewModel.Category;

namespace Api.Controllers
{
    [Route(Constants.Routes.Controller)]
    [ApiController]
    public class CategoriesController : GenericBaseController<CategoriesController>
    {
        public CategoriesController(IMediator mediator, Logging.Base.ILogger<CategoriesController> logger) : base(mediator, logger)
        {
        }

        [HttpPost(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(GetAllCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByParentId(GetAllCategoriesByParentIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<CategoryFilterViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByFilter(GetAllCategoriesByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<CategoryViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByRoute(GetCategoryByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CategoryServiceViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCategoryServices(GetAllCategoryServiceQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
