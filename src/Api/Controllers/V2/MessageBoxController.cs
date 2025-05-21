using Application.Features.MessageBox.Commands.ReadAllMessages;
using Application.Features.MessageBox.Queries.GetAllMessageBoxByFilter;
using ViewModels.QueriesResponseViewModel.MessageBox;
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
    public class MessageBoxController : GenericBaseController<MessageBoxController>
    {
        /// <inheritdoc />
        public MessageBoxController(IMediator mediator, Logging.Base.ILogger<MessageBoxController> logger, IMapper mapper) : base(mediator, logger, mapper)
        {
        }

        #region ( Queries )

        /// <summary>
        /// Returns all messages box by given filter
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<MessageBoxViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllMessageBoxByFilter([FromQuery] GetAllMessageBoxByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        #endregion

        #region ( Commands )

        /// <summary>
        /// Read All Messages command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<MessageBoxViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReadAllMessages(ReadAllMessagesCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        #endregion
    }
}