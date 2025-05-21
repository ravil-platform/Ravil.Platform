using Application.Features.PanelTutorial.Queries.Get;
using ViewModels.QueriesResponseViewModel.PanelTutorial;
using Asp.Versioning;
using AutoMapper;

namespace Api.Controllers.V2
{
    /// <inheritdoc />
    [ApiVersion(ApiVersions.V2)]
    [Route(Routes.Controller)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status401Unauthorized)]
    public class PanelTutorialsController : GenericBaseController<PanelTutorialsController>
    {
        /// <inheritdoc />
        public PanelTutorialsController(IMediator mediator, Logging.Base.ILogger<PanelTutorialsController> logger, IMapper mapper) : base(mediator, logger, mapper)
        {
        }

        #region ( Queries )

        /// <summary>
        /// Returns all Panel Tutorials Status
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<PanelTutorialViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] GetPanelTutorialsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        #endregion

        #region ( Commands )

        #endregion
    }
}
