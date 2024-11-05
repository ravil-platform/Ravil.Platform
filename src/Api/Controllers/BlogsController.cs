namespace Api.Controllers
{
    [Route(Constants.Routes.Controller)]
    [ApiController]
    public class BlogsController : GenericBaseController<BlogsController>
    {
        public BlogsController(IMediator mediator, Logging.Base.ILogger<BlogsController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<BlogFilterViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByFilter([FromQuery] GetAllBlogsByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<BlogViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByRoute([FromQuery] GetBlogByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BlogCategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlogCategories([FromQuery] GetBlogCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BlogCategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlogCategoriesByParentId([FromQuery] GetBlogCategoriesByParentIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        //todo : Crud
    }
}
