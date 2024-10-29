namespace Api.Controllers
{
    [Route(Constants.Routes.Controller)]
    [ApiController]
    public class UsersController : GenericBaseController<UsersController>
    {
        public UsersController(IMediator mediator, Logging.Base.ILogger<UsersController> logger)
            : base(mediator, logger)
        {
        }

        //for test api
        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        [HttpPost(Constants.Routes.Action)]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPost(Constants.Routes.Action)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GenerateToken(GenerateTokenCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
    }
}
