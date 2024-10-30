namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class MainSlidersController : GenericBaseController<MainSlidersController>
    {
        public MainSlidersController(IMediator mediator, Logging.Base.ILogger<MainSlidersController> logger) : base(mediator, logger)
        {

        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<MainSliderViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByFilter([FromQuery] GetAllMainSlidersByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
