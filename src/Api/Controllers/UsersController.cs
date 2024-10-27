namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : GenericBaseController<UsersController>
    {
        public UsersController(IMediator mediator, Logging.Base.ILogger<UsersController> logger) 
            : base(mediator, logger)
        {
        }

        //for test api
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GenerateToken(GenerateTokenCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
    }
}
