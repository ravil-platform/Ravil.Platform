namespace Application.Api;

public class BaseController : ControllerBase
{
    protected BaseController(MediatR.IMediator mediator) : base()
    {
        Mediator = mediator;
    }

    protected MediatR.IMediator Mediator { get; }

    protected IActionResult FluentResult<T>(FluentResults.Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Ok(value: result);
        }
        else
        {
            return BadRequest(error: result.ToResult());
        }
    }
}