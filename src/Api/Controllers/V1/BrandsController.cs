using AutoMapper;
using ViewModels.QueriesResponseViewModel.Brand;

namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class BrandsController : GenericBaseController<BrandsController>
    {
        public BrandsController(IMediator mediator, Logging.Base.ILogger<BrandsController> logger) : base(mediator, logger)
        {
        }

        #region ( Queries )
        /// <summary>
        /// Returns all brands
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BrandViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBrandsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        #endregion
    }
}
