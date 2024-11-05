namespace Api.Controllers
{
    [Route(Constants.Routes.Controller)]
    [ApiController]
    public class CategoriesController : GenericBaseController<CategoriesController>
    {
        public CategoriesController(IMediator mediator, Logging.Base.ILogger<CategoriesController> logger) : base(mediator, logger)
        {
        }

        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByParentId([FromQuery] GetAllCategoriesByParentIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<CategoryFilterViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByFilter([FromQuery] GetAllCategoriesByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<CategoryViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByRoute([FromQuery] GetCategoryByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CategoryServiceViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCategoryServices([FromQuery] GetAllCategoryServiceQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
