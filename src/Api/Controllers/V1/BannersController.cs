using Asp.Versioning;
using AutoMapper;

namespace Api.Controllers.V1
{
    /// <summary>
    /// BannersController
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="logger"></param>
    /// <param name="mapper"></param>
    [ApiVersion(ApiVersions.V1)]
    [Route(Routes.Controller)]
    public class BannersController(IMediator mediator, Logging.Base.ILogger<BannersController> logger, IMapper mapper)
        : GenericBaseController<BannersController>(mediator, logger, mapper)
    {
        #region ( Queries )
        /// <summary>
        /// Returns all banners
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BannerViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBannersQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all banners by given jobBranch id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BannerViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByBranchId([FromQuery] GetAllBannersByBranchIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all banners by given type
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BannerViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByType([FromQuery] GetAllBannersByTypeQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        #endregion
    }
}
