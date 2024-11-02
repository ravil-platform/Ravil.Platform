namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class ServicesController : GenericBaseController<ServicesController>
    {
        public ServicesController(IMediator mediator, Logging.Base.ILogger<ServicesController> logger) : base(mediator, logger)
        {
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<ServiceViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllServicesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<ServiceViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobServices([FromQuery] GetAllJobServiceQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CategoryServiceViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCategoryServices([FromQuery] GetAllCategoryServiceQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
