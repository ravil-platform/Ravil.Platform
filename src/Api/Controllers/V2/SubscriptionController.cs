using Application.Features.Subscription.Queries.GetAll;
using Application.Features.Subscription.Queries.GetByUserId;
using ViewModels.QueriesResponseViewModel.Subscription;
using Asp.Versioning;

namespace Api.Controllers.V2
{
    /// <inheritdoc />
    [Authorize]
    [ApiVersion(ApiVersions.V2)]
    [Route(Routes.Controller)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status401Unauthorized)]
    public class SubscriptionController : GenericBaseController<SubscriptionController>
    {
        /// <inheritdoc />
        public SubscriptionController(IMediator mediator, Logging.Base.ILogger<SubscriptionController> logger) : base(mediator, logger)
        {
        }

        #region ( Queries )

        /// <summary>
        /// Returns all subscription plans
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<SubscriptionViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSubscriptionPlanQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Return user(business owner) subscription plan
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<UserSubscriptionViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByUserId([FromQuery] GetUserSubscriptionPlanQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        #endregion

        #region ( Commands )

        #endregion
    }
}