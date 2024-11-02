namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class TeamsController : GenericBaseController<TeamsController>
    {
        public TeamsController(IMediator mediator, Logging.Base.ILogger<TeamsController> logger) : base(mediator, logger)
        {
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<TeamViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTeamsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
