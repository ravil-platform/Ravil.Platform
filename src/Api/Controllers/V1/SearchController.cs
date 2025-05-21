using Application.Features.Search.Queries;
using AutoMapper;
using ViewModels.QueriesResponseViewModel.Search;

namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class SearchController : GenericBaseController<SearchController>
    {
        public SearchController(IMediator mediator, Logging.Base.ILogger<SearchController> logger, IMapper mapper) : base(mediator, logger, mapper)
        {
        }

        /// <summary>
        /// Returns search result
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<SearchByCategoryAndJobQueryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SearchByCategoryAndJob([FromQuery] SearchByCategoryAndJobQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
