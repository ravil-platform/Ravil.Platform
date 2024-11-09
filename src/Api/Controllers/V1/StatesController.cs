//namespace Api.Controllers.V1
//{
//    [Route(Routes.Controller)]
//    public class StatesController : GenericBaseController<StatesController>
//    {
//        public StatesController(IMediator mediator, Logging.Base.ILogger<StatesController> logger) : base(mediator, logger)
//        {
//        }

//        /// <summary>
//        /// Returns all state bases
//        /// </summary>
//        /// <param name="query"></param>
//        /// <returns></returns>
//        [HttpGet(Routes.Action)]
//        [ProducesResponseType(type: typeof(Result<List<StateBaseViewModel>>), statusCode: StatusCodes.Status200OK)]
//        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
//        public async Task<IActionResult> GetAll([FromQuery] GetAllStatesQuery query)
//        {
//            var result = await Mediator.Send(query);

//            return FluentResult(result);
//        }

//        /// <summary>
//        /// Returns all states by iven state base id
//        /// </summary>
//        /// <param name="query"></param>
//        /// <returns></returns>
//        [HttpGet(Routes.Action)]
//        [ProducesResponseType(type: typeof(Result<List<StateBaseViewModel>>), statusCode: StatusCodes.Status200OK)]
//        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
//        public async Task<IActionResult> GetAllByStateBaseId([FromQuery] GetAllStatesByStateBaseIdQuery query)
//        {
//            var result = await Mediator.Send(query);

//            return FluentResult(result);
//        }

//        /// <summary>
//        /// Returns all state bases
//        /// </summary>
//        /// <param name="query"></param>
//        /// <returns></returns>
//        [HttpGet(Routes.Action)]
//        [ProducesResponseType(type: typeof(Result<List<StateBaseViewModel>>), statusCode: StatusCodes.Status200OK)]
//        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
//        public async Task<IActionResult> GetAllStateBases([FromQuery] GetAllStateBaseQuery query)
//        {
//            var result = await Mediator.Send(query);

//            return FluentResult(result);
//        }
//    }
//}