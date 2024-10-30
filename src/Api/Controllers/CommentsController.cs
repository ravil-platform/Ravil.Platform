using Application.Features.Comment.Commands.Create;
using Application.Features.Comment.Commands.CreateAnswer;
using Application.Features.Comment.Queries.GetAll;
using Application.Features.Comment.Queries.GetAllAnswersByCommentId;
using ViewModels.QueriesResponseViewModel.Comment;

namespace Api.Controllers
{
    [Route(Routes.Controller)]
    [ApiController]
    public class CommentsController : GenericBaseController<CommentsController>
    {
        public CommentsController(IMediator mediator, Logging.Base.ILogger<CommentsController> logger) : base(mediator, logger)
        {
        }

        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<CommentViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCommentsByFilter([FromQuery] GetCommentsByFilterQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }


        [HttpGet(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<AnswerCommentViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAnswersByFilter([FromQuery] GetAnswersByCommentIdQuery query)
        {
            var result = await Mediator.Send(query);

            return FluentResult(result);
        }

        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<CommentViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateCommentCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }

        [HttpPost(Routes.Action)]
        [ProducesResponseType(type: typeof(Result<AnswerCommentViewModel>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsnwerComment(CreateAnswerCommentCommand command)
        {
            var result = await Mediator.Send(command);

            return FluentResult(result);
        }
    }
}
