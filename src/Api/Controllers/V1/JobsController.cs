using Application.Features.Job.Queries.GetJobBranchByRoute;

namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class JobsController : GenericBaseController<JobsController>
    {
        public JobsController(IMediator mediator, Logging.Base.ILogger<JobsController> logger) : base(mediator, logger)
        {

        }

        #region ( Queries )
        /// <summary>
        /// Returns all advertising job branches 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAdvertisingJobs([FromQuery] GetAdvertisingJobsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns job branches with a given categoryId and cityId and take entities
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchFilter>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRelatedJobBranches([FromQuery] GetRelatedJobBranchesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Returns all job branches by given filter
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchFilter>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchesByFilter([FromQuery] GetAllJobBranchByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all job branches by given job id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchesByJobId([FromQuery] GetAllJobBranchByJobIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns job branch by unique id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchById([FromQuery] GetJobBranchByIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns job branch by unique route
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchByRoute([FromQuery] GetJobBranchByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all job services 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobServiceViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobServices([FromQuery] GetAllJobServiceQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns newest jobs
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetNewestJobs([FromQuery] GetNewestJobsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns best jobs
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBestJobs([FromQuery] GetBestJobsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns Related jobs
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRelatedJobs([FromQuery] GetRelatedJobsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns a job by given route
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByRoute([FromQuery] GetJobByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all jobs by given category id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobsByCategoryId([FromQuery] GetAllJobsByCategoryIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all job selection slider by given filter
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobSelectionSliderByFilter([FromQuery] GetJobSelectionSliderQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all job branch short links by given job branch id 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchShortLinkViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchShortLinksByJobBranchId([FromQuery] GetJobBranchShortLinksQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Returns all job branch galleries by given job branch id 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchGalleryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchGalleriesByJobBranchId([FromQuery] GetJobBranchGalleriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Returns all job time works by given job branch id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobTimeWorkViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobTimeWorkByJobBranchId([FromQuery] GetJobTimeWorksQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        #endregion

        #region ( Commands )
        /// <summary>
        /// Creates a job
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateJob([FromForm] CreateJobCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Creates a job category
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateJobCategory(CreateJobCategoryCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Creates a job branch
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateJobBranch([FromForm] CreateJobBranchCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Creates a job and also job branch ( add free job in ravil ) 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateFreeJobBranch([FromForm] CreateFreeJobBranchCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        /// <summary>
        /// Upload job branch video
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadJobBranchVideo([FromForm] UploadJobBranchVideoCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        /// <summary>
        /// Upload job branch galleries
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadJobBranchGalleries([FromForm] UploadJobBranchGalleriesCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Upload job branch image
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadJobBranchImage([FromForm] UploadJobBranchImageCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Update a job branch 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<UpdateJobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateJobBranch([FromForm] UpdateJobBranchCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Update a job branch location
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<UpdateJobBranchLocationViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateJobBranchLocation([FromForm] UpdateJobBranchLocationCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Update a job 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateJob(UpdateJobCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Update a job category
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateJobCategory(UpdateJobCategoryCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
        #endregion
    }
}