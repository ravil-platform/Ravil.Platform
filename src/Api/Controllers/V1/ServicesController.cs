//namespace Api.Controllers.V1
//{
//    [Route(Routes.Controller)]
//    public class ServicesController : GenericBaseController<ServicesController>
//    {
//        public ServicesController(IMediator mediator, Logging.Base.ILogger<ServicesController> logger) : base(mediator, logger)
//        {
//        }

//        /// <summary>
//        /// Returns all services 
//        /// </summary>
//        /// <param name="query"></param>
//        /// <returns></returns>
//        [HttpGet(Routes.Action)]
//        [ProducesResponseType(type: typeof(Result<List<ServiceViewModel>>), statusCode: StatusCodes.Status200OK)]
//        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
//        public async Task<IActionResult> GetAll([FromQuery] GetAllServicesQuery query)
//        {
//            var result = await Mediator.Send(query);

//            return FluentResult(result);
//        }

//        /// <summary>
//        /// Returns all job services
//        /// </summary>
//        /// <param name="query"></param>
//        /// <returns></returns>
//        [HttpGet(Routes.Action)]
//        [ProducesResponseType(type: typeof(Result<List<JobServiceViewModel>>), statusCode: StatusCodes.Status200OK)]
//        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
//        public async Task<IActionResult> GetJobServices([FromQuery] GetAllJobServiceQuery query)
//        {
//            var result = await Mediator.Send(query);

//            return FluentResult(result);
//        }

//        /// <summary>
//        /// Returns all category services 
//        /// </summary>
//        /// <param name="query"></param>
//        /// <returns></returns>
//        [HttpGet(Routes.Action)]
//        [ProducesResponseType(type: typeof(Result<List<CategoryServiceViewModel>>), statusCode: StatusCodes.Status200OK)]
//        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
//        public async Task<IActionResult> GetCategoryServices([FromQuery] GetAllCategoryServiceQuery query)
//        {
//            var result = await Mediator.Send(query);

//            return FluentResult(result);
//        }
//    }
//}