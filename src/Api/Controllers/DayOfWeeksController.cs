namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class DayOfWeeksController : GenericBaseController<DayOfWeeksController>
    {
        public DayOfWeeksController(IMediator mediator, Logging.Base.ILogger<DayOfWeeksController> logger) : base(mediator, logger)
        {
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<DayOfWeekViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDayOfWeekQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
