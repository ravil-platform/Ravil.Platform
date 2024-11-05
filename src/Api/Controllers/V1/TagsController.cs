namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class TagsController : GenericBaseController<TagsController>
    {
        public TagsController(IMediator mediator, Logging.Base.ILogger<TagsController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Returns all tags
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<TagViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTagsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Returns all tags by given type
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<TagViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByType([FromQuery] GetAllTagsByTypeQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns blog tags by given blog id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BlogTagViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlogTagsByBlogId([FromQuery] GetBlogTagsByIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns job tags by given job id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobTagViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobTagsByJobId([FromQuery] GetJobTagsByIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns job branch tags by job branch id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchTagViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchTagsByJobBranchId([FromQuery] GetJobBranchTagsByIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
