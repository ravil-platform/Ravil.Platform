namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class ConfigsController : GenericBaseController<ConfigsController>
    {
        public ConfigsController(IMediator mediator, Logging.Base.ILogger<ConfigsController> logger) : base(mediator, logger)
        {
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<ConfigViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] GetConfigQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
