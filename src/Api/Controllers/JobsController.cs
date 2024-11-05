namespace Api.Controllers
{
    [Route(Constants.Routes.Controller)]
    [ApiController]
    public class JobsController : GenericBaseController<JobsController>
    {
        public JobsController(IMediator mediator, Logging.Base.ILogger<JobsController> logger) : base(mediator, logger)
        {

        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchFilter>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchesByFilter([FromQuery] GetAllJobBranchByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchesByJobId([FromQuery] GetAllJobBranchByJobIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchById([FromQuery] GetJobBranchByIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<ServiceViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobServices([FromQuery] GetAllJobServiceQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetNewestJobs([FromQuery] GetNewestJobsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBestJobs([FromQuery] GetBestJobsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRelatedJobs([FromQuery] GetRelatedJobsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByRoute([FromQuery] GetJobByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobsByCategoryId([FromQuery] GetAllJobsByCategoryIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobSelectionSliderViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobSelectionSliderByFilter([FromQuery] GetJobSelectionSliderQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchShortLinkViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchShortLinksByJobBranchId([FromQuery] GetJobBranchShortLinksQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchGalleryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchGalleriesByJobBranchId([FromQuery] GetJobBranchGalleriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobTimeWorkViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobTimeWorkByJobBranchId([FromQuery] GetJobTimeWorksQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateJob([FromForm] CreateJobCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateJobCategory(CreateJobCategoryCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateJobBranch([FromForm] CreateJobBranchCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateFreeJobBranch([FromForm] CreateFreeJobBranchCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadJobBranchVideo([FromForm] UploadJobBranchVideoCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadJobBranchGalleries([FromForm] UploadJobBranchGalleriesCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadJobBranchImage([FromForm] UploadJobBranchImageCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPut(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<UpdateJobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateJobBranch([FromForm] UpdateJobBranchCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPut(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<UpdateJobBranchLocationViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateJobBranchLocation([FromForm] UpdateJobBranchLocationCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        [HttpPut(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateJob(UpdateJobCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPut(Constants.Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateJobCategory(UpdateJobCategoryCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

    
    }
}