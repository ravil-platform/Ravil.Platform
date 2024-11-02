namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class BannersController : GenericBaseController<BannersController>
    {
        public BannersController(IMediator mediator, Logging.Base.ILogger<BannersController> logger) : base(mediator, logger)
        {
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BannerViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBannersQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BannerViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByBranchId([FromQuery] GetAllBannersByBranchIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BannerViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByType([FromQuery] GetAllBannersByTypeQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
