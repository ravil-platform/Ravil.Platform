namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class FaqsController : GenericBaseController<FaqsController>
    {
        public FaqsController(IMediator mediator, Logging.Base.ILogger<FaqsController> logger) : base(mediator, logger)
        {
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<FaqViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFaqsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<FaqViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByCategoryId([FromQuery] GetAllFaqsByCategoryIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<FaqCategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllFaqCategories([FromQuery] GetAllFaqCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
