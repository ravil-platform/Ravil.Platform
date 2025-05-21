using Application.Features.Blog.Queries.GetAll;
using Application.Features.Blog.Queries.GetById;
using Application.Features.Job.Queries.GetAll;
using AutoMapper;

namespace Api.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="logger"></param>
    /// <param name="mapper"></param>
    [Route(Routes.Controller)]
    public class BlogsController(IMediator mediator, Logging.Base.ILogger<BlogsController> logger, IMapper mapper)
        : GenericBaseController<BlogsController>(mediator, logger, mapper)
    {
        #region ( Queries )
        /// <summary>
        /// Returns all blogs (using for seo)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BlogViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBlogsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all blogs by given filter
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<BlogFilterViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByFilter([FromQuery] GetAllBlogsByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns a blog by given route
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<BlogViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByRoute([FromQuery] GetBlogByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns a blog by given Id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<BlogViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromQuery] GetBlogByIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all blog categories 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BlogCategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlogCategories([FromQuery] GetBlogCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        /// <summary>
        /// Returns all blog categories by given parent id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BlogCategoryViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlogCategoriesByParentId([FromQuery] GetBlogCategoriesByParentIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        #endregion
    }
}
