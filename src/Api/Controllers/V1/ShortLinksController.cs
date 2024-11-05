namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class ShortLinksController : GenericBaseController<ShortLinksController>
    {
        public ShortLinksController(IMediator mediator, Logging.Base.ILogger<ShortLinksController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Returns all short links
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<ShortLinkViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllShortLinkQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all short link by item id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<ShortLinkViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByItemId([FromQuery] GetAllShortLinkByItemIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
