using Application.Features.Brand.Queries.GetAll;
using Domain.Entities.Brand;

namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class BrandsController : GenericBaseController<BrandsController>
    {
        public BrandsController(IMediator mediator, Logging.Base.ILogger<BrandsController> logger) : base(mediator, logger)
        {
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<BrandViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBrandsQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
    }
}
