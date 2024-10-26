using Application.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : GenericBaseController<UsersController>
    {
        public UsersController(IMediator mediator, Logging.Base.ILogger<UsersController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
