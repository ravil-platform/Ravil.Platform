using Application.Features.Job.Commands.AdsClickActivity;
using Application.Features.Job.Commands.RechargeAdsClick;
using Application.Features.Job.Commands.RechargeAdsClickVerification;
using Application.Features.Job.Commands.RemoveJobBranchGalleries;
using Application.Features.Job.Commands.SetAdsClickSetting;
using Application.Features.Job.Commands.UpdateBusiness;
using Application.Features.Job.Queries.GetAllKeywords;
using Application.Features.Job.Queries.GetJobBranchByUserId;
using Application.Features.Job.Queries.GetRecommendationJob;
using Application.Features.Job.Queries.Report;
using ViewModels.QueriesResponseViewModel.Subscription;
using Asp.Versioning;
using AutoMapper;

namespace Api.Controllers.V2
{
    /// <inheritdoc />
    [ApiVersion(ApiVersions.V2)]
    [Route(Routes.Controller)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status401Unauthorized)]
    public class JobsController : GenericBaseController<JobsController>
    {
        /// <inheritdoc />
        public JobsController(IMediator mediator, Logging.Base.ILogger<JobsController> logger, IMapper mapper)
            : base(mediator, logger, mapper)
        {

        }

        #region ( Queries )

        /// <summary>
        /// Returns job branch by user id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobBranchByUserId([FromQuery] GetJobBranchByUserIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Returns report job clicks information
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<SubscriptionClickViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Report([FromQuery] JobReportQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Returns all keywords tag list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<KeywordViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllKeywords([FromQuery] GetAllKeywordsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        /// <summary>
        /// Returns job recommendation
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<JobBranchViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRecommendation([FromBody] GetRecommendationJobCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
        #endregion

        #region ( Commands )

        /// <summary>
        /// Creates a job and also job branch ( add free job in ravil ) 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateFreeJobBranch([FromForm] CreateFreeJobBranchCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Update a Business (job) 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<JobBranchViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateBusiness([FromForm] UpdateBusinessCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        /// <summary>
        /// Upload job branch galleries
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveJobBranchGallery([FromBody] RemoveJobBranchGalleriesCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Ads Click action command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdsClickActivity(AdsClickActivityCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Set Ads Click settings for each user command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<ClickAdsSettingViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> SetAdsClickSetting(SetAdsClickSettingCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Recharge Ads Click account command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<RechargeAdsClickViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RechargeAdsClick(RechargeAdsClickCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Verify Recharge Ads Click command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<RechargeAdsClickVerificationViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RechargeAdsClickVerification(RechargeAdsClickVerificationCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }



        /*/// <summary>
        /// Upload job branch galleries
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveJobBranchGallery([FromBody] RemoveJobBranchGalleriesCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Ads Click action
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdsClickActivity(AdsClickActivityCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }*/
        #endregion
    }
}