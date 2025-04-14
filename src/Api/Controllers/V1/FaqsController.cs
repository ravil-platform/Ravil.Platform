namespace Api.Controllers.V1
{
    /// <inheritdoc />
    [Route(Routes.Controller)]
    public class FaqsController : GenericBaseController<FaqsController>
    {
        /// <inheritdoc />
        public FaqsController(IMediator mediator, Logging.Base.ILogger<FaqsController> logger) : base(mediator, logger)
        {
        }

        #region ( Queries )
        /// <summary>
        /// Returns all faqs
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<FaqViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFaqsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all faqs by given category id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<FaqViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByCategoryId([FromQuery] GetAllFaqsByCategoryIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all faq categories
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<FaqCategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllFaqCategories([FromQuery] GetAllFaqCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        #endregion
    }
}
