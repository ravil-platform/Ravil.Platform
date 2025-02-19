using Application.Features.City.Queries.GetCityBaseByLocation;

namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class CitiesController : GenericBaseController<CitiesController>
    {
        public CitiesController(IMediator mediator, Logging.Base.ILogger<CitiesController> logger) : base(mediator, logger)
        {
        }

        #region ( Queries )
        /// <summary>
        /// Returns all cities
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CityViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCitiesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Returns all cities by given city base id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CityViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByCityBaseId([FromQuery] GetAllCitiesByCityBaseIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Returns all cityBases
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CityBaseViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCityBase([FromQuery] GetAllCityBaseQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Returns all cityCategories
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CityCategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCityCategory([FromQuery] GetAllCityCategoryQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Return CityBase Data From Location Data (Latitude, Longitude)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<CityInfoViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCityBaseByLocation([FromQuery] GetCityBaseByLocationQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        #endregion
    }
}
