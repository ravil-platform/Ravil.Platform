namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class MainSlidersController : GenericBaseController<MainSlidersController>
    {
        public MainSlidersController(IMediator mediator, Logging.Base.ILogger<MainSlidersController> logger) : base(mediator, logger)
        {

        }

        /// <summary>
        /// Returns all main sliders 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<MainSliderViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByFilter([FromQuery] GetAllMainSlidersByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
