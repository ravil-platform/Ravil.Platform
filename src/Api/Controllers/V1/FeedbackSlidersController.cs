using Application.Features.FeedbackSlider.Queries.GetAllByFilter;
using Microsoft.AspNetCore.Mvc;
using ViewModels.QueriesResponseViewModel.FeedbackSlider;

namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class FeedbackSlidersController : GenericBaseController<FeedbackSlidersController>
    {
        public FeedbackSlidersController(IMediator mediator, Logging.Base.ILogger<FeedbackSlidersController> logger) : base(mediator, logger)
        {

        }

        /// <summary>
        /// Returns feed back sliders by given filter
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<FeedbackSliderViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByFilter([FromQuery] GetAllFeedbackSliderByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
