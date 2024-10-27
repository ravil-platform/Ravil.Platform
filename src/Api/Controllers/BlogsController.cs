using Application.Features.Blogs.Queries.GetAllByFilter;
using Application.Features.Blogs.Queries.GetBlogCategories;
using Application.Features.Blogs.Queries.GetBlogCategoriesByParentId;
using Application.Features.Blogs.Queries.GetByRoute;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : GenericBaseController<BlogsController>
    {
        public BlogsController(IMediator mediator, Logging.Base.ILogger<BlogsController> logger)
            : base(mediator, logger)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllByFilter(GetAllBlogsByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetByRoute(GetBlogByRouteQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetBlogCategories(GetBlogCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetBlogCategoriesByParentId(GetBlogCategoriesByParentIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        //todo : Crud
    }
}
