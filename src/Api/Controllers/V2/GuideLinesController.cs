using ViewModels.QueriesResponseViewModel.Job.GuideLines;
using Application.Features.GuideLine.Commands.GuideLineCompletion;
using Application.Features.GuideLine.Queries.GetGuideLines;
using Asp.Versioning;

namespace Api.Controllers.V2
{
    /// <inheritdoc />
    [Authorize]
    [ApiVersion(ApiVersions.V2)]
    [Route(Routes.Controller)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status401Unauthorized)]
    public class GuideLinesController : GenericBaseController<GuideLinesController>
    {
        /// <inheritdoc />
        public GuideLinesController(IMediator mediator, Logging.Base.ILogger<GuideLinesController> logger) : base(mediator, logger)
        {
        }

        #region ( Queries )

        /// <summary>
        /// Returns all Guide Lines Status
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<GuideLineCompletionViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] GetGuideLinesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        #endregion

        #region ( Commands )
        
        /// <summary>
        /// Update Guide Line Status action
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<GuideLineCompletionViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GuideLineCompletion([FromForm] GuideLineCompletionCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        #endregion
    }
}
