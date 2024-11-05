using Application.Contracts.Identity;

namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class UsersController : GenericBaseController<UsersController>
    {
        public UsersController(IMediator mediator, Logging.Base.ILogger<UsersController> logger)
            : base(mediator, logger)
        {
        }
        /// <summary>
        /// this action for test
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// this action used for login or register user and gives you a JWT token
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<RegisterUserResponseViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAndLogin(RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        /// <summary>
        /// Generate JWT token for given user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<AccessToken>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> GenerateToken(GenerateTokenCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
    }
}
