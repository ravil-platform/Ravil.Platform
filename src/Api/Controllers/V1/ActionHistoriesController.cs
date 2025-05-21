using Application.Features.ActionHistories.Create;
using Asp.Versioning;
using AutoMapper;

namespace Api.Controllers.V1
{
    /// <inheritdoc />
    [ApiVersion(ApiVersions.V1)]
    [Route(Routes.Controller)]
    public class ActionHistoriesController : GenericBaseController<ActionHistoriesController>
    {
        /// <summary>
        /// ActionHistoriesController Constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public ActionHistoriesController(IMediator mediator, Logging.Base.ILogger<ActionHistoriesController> logger, IMapper mapper) : base(mediator, logger, mapper)
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