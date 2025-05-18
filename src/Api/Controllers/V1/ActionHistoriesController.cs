using Application.Features.ActionHistories.Create;

namespace Api.Controllers.V1
{
    /// <inheritdoc />
    [Route(Routes.Controller)]
    public class ActionHistoriesController : GenericBaseController<ActionHistoriesController>
    {
        /// <summary>
        /// ActionHistoriesController Constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public ActionHistoriesController(IMediator mediator, Logging.Base.ILogger<ActionHistoriesController> logger) : base(mediator, logger)
        {

        }

        #region ( Commands )
        /// <summary>
        /// Creates an Action History
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateActionHistoriesCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
        #endregion
    }
}