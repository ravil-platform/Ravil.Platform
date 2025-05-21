using AutoMapper;

namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class ConfigsController : GenericBaseController<ConfigsController>
    {
        public ConfigsController(IMediator mediator, Logging.Base.ILogger<ConfigsController> logger, IMapper mapper) : base(mediator, logger, mapper)
        {
        }

        #region ( Queries )
        /// <summary>
        /// Returns all configs
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<ConfigViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] GetConfigQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        #endregion
    }
}
