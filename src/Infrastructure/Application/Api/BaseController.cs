using MediatR;

namespace Application.Api;

public class BaseController : ControllerBase
{
    protected MediatR.IMediator Mediator { get; }
    protected AutoMapper.IMapper Mapper { get; }

    protected BaseController(IMediator mediator, IMapper mapper)
    {
        Mediator = mediator;
        Mapper = mapper;
    }

    protected IActionResult FluentResult<T>(FluentResults.Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Ok(value: RNX.CustomResult.CustomResult<T>.ToCustomResult(result));
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