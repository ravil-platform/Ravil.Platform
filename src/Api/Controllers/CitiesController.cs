namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class CitiesController : GenericBaseController<CitiesController>
    {
        public CitiesController(IMediator mediator, Logging.Base.ILogger<CitiesController> logger) : base(mediator, logger)
        {
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CityViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCitiesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }



        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CityViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByCityBaseId([FromQuery] GetAllCitiesByCityBaseIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }



        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CityBaseViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCityBase([FromQuery] GetAllCityBaseQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }



        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<CityCategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCityCategory([FromQuery] GetAllCityCategoryQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
