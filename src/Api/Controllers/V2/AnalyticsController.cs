using Application.Features.Job.Commands.AddJobRanking;
using Application.Features.Job.Queries.GetContactRequests;
using Application.Features.Job.Queries.GetJobOverView;
using Application.Features.Job.Queries.GetJobRankingsByFilter;
using Application.Features.Job.Queries.GetJobStatisticsByFilter;
using Application.Features.Job.Queries.GetJobViews;
using Application.Features.Job.Queries.GetReviewsSummery;
using Application.Features.Job.Queries.GetTagsPotential;
using ViewModels.QueriesResponseViewModel.Analytics;
using Asp.Versioning;
using Application.Features.Job.Commands.AdsClickActivity;

namespace Api.Controllers.V2
{
    /// <inheritdoc />
    [Authorize]
    [ApiVersion(ApiVersions.V2)]
    [Route(Routes.Controller)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status401Unauthorized)]
    public class AnalyticsController : GenericBaseController<AnalyticsController>
    {
        /// <inheritdoc />
        public AnalyticsController(IMediator mediator, Logging.Base.ILogger<AnalyticsController> logger) : base(mediator, logger)
        {
        }
        
        #region ( Queries )
        
        /// <summary>
        /// Returns job overview by given jobId
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobOverViewViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> OverView([FromQuery] JobOverViewQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        
        /// <summary>
        /// Returns job views by given jobId
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobViewsViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetViews([FromQuery] GetJobViewsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        
        /// <summary>
        /// Returns review summery by given jobId
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<ReviewsSummeryViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetReviewsSummery([FromQuery] GetReviewsSummeryQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        
        /// <summary>
        /// Returns tags potential by given jobId
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<TagsPotentialViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTagsPotential([FromQuery] GetTagsPotentialQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns Contact Requests (phone, map, social media) by given jobId
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<ContactRequestViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetContactRequests([FromQuery] GetContactRequestsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns job statistics by given filter
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobStatisticsViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobStatisticsByFilter([FromQuery] GetJobStatisticsByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        
        /// <summary>
        /// Returns all job rankings by given filter
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobRankingViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobRankingsByFilter([FromQuery] GetJobRankingsByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        #endregion

        #region ( Commands )

        /// <summary>
        /// Add Job Ranking History command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddJobRanking(AddJobRankingCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        #endregion
    }
}