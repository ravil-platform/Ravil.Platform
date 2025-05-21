using AutoMapper;

namespace Api.Controllers.V1
{
    /// <inheritdoc />
    [Route(Routes.Controller)]
    public class TeamsController : GenericBaseController<TeamsController>
    {
        /// <inheritdoc />
        public TeamsController(IMediator mediator, Logging.Base.ILogger<TeamsController> logger, IMapper mapper) : base(mediator, logger, mapper)
        {
        }

        #region ( Queries )  
        /// <summary>
        /// Returns all teams
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<TeamViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTeamsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        #endregion
    }
}
