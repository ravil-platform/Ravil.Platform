namespace Api.Controllers
{
    [Route(Constants.Routes.Controller)]
    [ApiController]
    public class JobsController : GenericBaseController<JobsController>
    {
        public JobsController(IMediator mediator, Logging.Base.ILogger<JobsController> logger) : base(mediator, logger)
        {

        }

        [HttpGet(Constants.Routes.Action)]
        public async Task<IActionResult> GetNewestJobs([FromQuery] GetNewestJobsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpGet(Constants.Routes.Action)]
        public async Task<IActionResult> GetBestJobs([FromQuery] GetBestJobsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpGet(Constants.Routes.Action)]
        public async Task<IActionResult> GetRelatedJobs([FromQuery] GetRelatedJobsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpGet(Constants.Routes.Action)]
        public async Task<IActionResult> GetByRoute([FromQuery] GetJobByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpGet(Constants.Routes.Action)]
        public async Task<IActionResult> GetJobsByCategoryId([FromQuery] GetAllJobsByCategoryIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> CreateJob([FromForm] CreateJobCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPut(Constants.Routes.Action)]
        public async Task<IActionResult> UpdateJob(UpdateJobCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> CreateJobCategory(CreateJobCategoryCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPut(Constants.Routes.Action)]
        public async Task<IActionResult> UpdateJobCategory(UpdateJobCategoryCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> CreateJobBranch([FromForm] CreateJobBranchCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> CreateFreeJobBranch([FromForm] CreateFreeJobBranchCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
    }
}