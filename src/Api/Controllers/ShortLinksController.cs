using Application.Features.ShortLink.Queries.GetAll;
using Application.Features.ShortLink.Queries.GetAllByItemId;
using ViewModels.QueriesResponseViewModel.ShortLink;

namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class ShortLinksController : GenericBaseController<ShortLinksController>
    {
        public ShortLinksController(IMediator mediator, Logging.Base.ILogger<ShortLinksController> logger) : base(mediator, logger)
        {
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<ShortLinkViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllShortLinkQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<ShortLinkViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByItemId([FromQuery] GetAllShortLinkByItemIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
