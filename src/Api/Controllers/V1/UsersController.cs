using ViewModels.QueriesResponseViewModel.User;

namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class UsersController : GenericBaseController<UsersController>
    {
        public UsersController(IMediator mediator, Logging.Base.ILogger<UsersController> logger)
            : base(mediator, logger)
        {
        }

        [HttpPost(Routes.Action)]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<RegisterUserResponseViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAndLogin(RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPost(Routes.Action)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GenerateToken(GenerateTokenCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
    }
}
