namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class TagsController : GenericBaseController<TagsController>
    {
        public TagsController(IMediator mediator, Logging.Base.ILogger<TagsController> logger) : base(mediator, logger)
        {
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<TagViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTagsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<TagViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByType([FromQuery] GetAllTagsByTypeQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BlogTagViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlogTagsByBlogId([FromQuery] GetBlogTagsByIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobTagViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobTagsByJobId([FromQuery] GetJobTagsByIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


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
