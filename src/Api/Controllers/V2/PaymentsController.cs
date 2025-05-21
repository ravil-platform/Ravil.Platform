using Application.Features.Payments.Commands.Payment;
using Application.Features.Payments.Commands.PaymentVerification;
using Application.Features.Payments.Queries.GetPaymentPortals;
using ViewModels.QueriesResponseViewModel.Payments;
using Asp.Versioning;
using AutoMapper;


namespace Api.Controllers.V2
{
    /// <inheritdoc />
    [Authorize]
    [ApiVersion(ApiVersions.V2)]
    [Route(Routes.Controller)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status403Forbidden)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status401Unauthorized)]
    public class PaymentsController : GenericBaseController<PaymentsController>
    {
        /// <inheritdoc />
        public PaymentsController(IMediator mediator, Logging.Base.ILogger<PaymentsController> logger, IMapper mapper) : base(mediator, logger, mapper)
        {
        }

        #region ( Commands )

        /// <summary>
        /// Payment Action Command
        /// </summary>
        /// <param name="command"></param>
        /// <typeparam name="'PaymentCommand'">The type returned from this method</typeparam>
        /// <returns>FluentResults.Result</returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<PaymentActionResponseViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Payment(PaymentCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Payment Verification Action Command
        /// </summary>
        /// <param name="command"></param>
        /// <typeparam name="'PaymentVerificationCommand'">The type returned from this method</typeparam>
        /// <returns>FluentResults.Result</returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<PaymentVerificationResponseViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Verification([FromQuery] PaymentVerificationCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        #endregion

        #region ( Queries )

        /// <summary>
        /// Get Payment Portals
        /// </summary>
        /// <param name="query"></param>
        /// <returns>FluentResults.Result</returns>
        [AllowAnonymous]
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<PaymentPortalViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPortals([FromQuery] GetPaymentPortalsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        #endregion
    }
}