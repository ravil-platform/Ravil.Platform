using MediatR;

namespace Application.Api;

public class BaseController : ControllerBase
{
    protected MediatR.IMediator Mediator { get; }

    public BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }

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

    protected IActionResult FluentResult(FluentResults.Result result)
    {
        if (result.IsSuccess)
        {
            return Ok(value: result);
        }
        else
        {
            return BadRequest(error: result.WithError(Resources.Messages.Errors.ActionsHasError));
        }
    }
}