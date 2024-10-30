using Application.Features.State.Queries.GetAll;
using Application.Features.State.Queries.GetAllByStateBaseId;
using Application.Features.State.Queries.GetAllStateBase;
using ViewModels.QueriesResponseViewModel.State;

namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class StatesController : GenericBaseController<StatesController>
    {
        public StatesController(IMediator mediator, Logging.Base.ILogger<StatesController> logger) : base(mediator, logger)
        {
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<StateBaseViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllStatesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<StateBaseViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByStateBaseId([FromQuery] GetAllStatesByStateBaseIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<StateBaseViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllStateBases([FromQuery] GetAllStateBaseQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}