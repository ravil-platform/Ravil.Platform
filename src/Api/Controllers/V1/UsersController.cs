namespace Api.Controllers.V1
{
    [Route(Routes.Controller)]
    public class UsersController : GenericBaseController<UsersController>
    {
        public UsersController(IMediator mediator, Logging.Base.ILogger<UsersController> logger)
            : base(mediator, logger)
        {
        }

        #region ( Queries )
        /// <summary>
        /// Returns a user by unique id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<ApplicationUserViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromQuery] GetUserByIdQuery command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
        #endregion

        #region ( Commands )
        /// <summary>
        /// Using this action for create a user and test the system if you want (test)
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost(Routes.Action)]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        /// <summary>
        /// This action used for login or register user and gives you a JWT token and refresh token . (send sms code as null for register)
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<RegisterOrLoginUserResponseViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterOrLogin(RegisterOrLoginUserCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Send sms code again for register or login user for given phone number (do not fill sms code)
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<RegisterOrLoginUserResponseViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendSmsCode(RegisterOrLoginUserCommand command)
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


        /// <summary>
        /// Find user token by given refresh token id and gives you a new token
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<AccessToken>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
        #endregion
    }
}
