namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class DayOfWeeksController : GenericBaseController<DayOfWeeksController>
    {
        public DayOfWeeksController(IMediator mediator, Logging.Base.ILogger<DayOfWeeksController> logger) : base(mediator, logger)
        {
        }

        #region ( Queries )
        /// <summary>
        /// Returns all day of weeks
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<DayOfWeekViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDayOfWeekQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        #endregion
    }
}
