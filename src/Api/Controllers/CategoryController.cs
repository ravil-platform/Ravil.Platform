namespace Api.Controllers
{
    [Route(Constants.Routes.Controller)]
    [ApiController]
    public class CategoryController : GenericBaseController<CategoryController>
    {
        public CategoryController(IMediator mediator, Logging.Base.ILogger<CategoryController> logger) : base(mediator, logger)
        {
        }

        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> GetAll(GetAllCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> GetAllByParentId(GetAllCategoriesByParentIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> GetAllByFilter(GetAllCategoriesByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> GetByRoute(GetCategoryByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> GetCategoryServices(GetAllCategoryServiceQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
