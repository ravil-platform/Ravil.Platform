using Application.Features.User.Commands.RemoveToken;

namespace Api.Controllers.V1
{

    [Route(Routes.Controller)]
    [Authorize]
    public class UserProfileController : GenericBaseController<UserProfileController>
    {
        public UserProfileController(IMediator mediator, Logging.Base.ILogger<UserProfileController> logger) : base(mediator, logger)
        {
        }

        #region ( Queries )
        /// <summary>
        /// Returns user job branches for given user id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<List<UserJobBranchesViewModel>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserJobBranches([FromQuery] GetUserJobBranchesQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }
        #endregion

        #region ( Commands )
        /// <summary>
        /// Add blog like with given blog id and user id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBlogLike(AddBlogLikeCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        /// <summary>
        /// Add blog or branch to bookmark for given user id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddToBookMark(AddToBookMarkCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        /// <summary>
        /// Remove a bookmark from unique id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveBookMark(RemoveBookMarkCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Upload user avatar for given user id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadUserAvatar(UploadUserAvatarCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }


        /// <summary>
        /// Updates user info for given user id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Routes.Action)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserInfo(UpdateUserInfoCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        /// <summary>
        /// Remove user token by given jwt token
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Routes.Action)]
        public async Task<IActionResult> Logout(RemoveUserTokenCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
        #endregion
    }
}
