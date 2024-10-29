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

        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> GetAllByFilter(GetAllBlogsByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpGet(Constants.Routes.Action)]
        public async Task<IActionResult> GetByRoute([FromQuery] GetBlogByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> GetBlogCategories(GetBlogCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> GetBlogCategoriesByParentId(GetBlogCategoriesByParentIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        //todo : Crud
    }
}
