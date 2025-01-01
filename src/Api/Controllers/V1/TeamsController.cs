namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class TeamsController : GenericBaseController<TeamsController>
    {
        public TeamsController(IMediator mediator, Logging.Base.ILogger<TeamsController> logger) : base(mediator, logger)
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
