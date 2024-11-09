using MediatR;
using RNX.CustomResult;

namespace Application.Api;

public class BaseController : ControllerBase
{
    protected MediatR.IMediator Mediator { get; }
    protected IMapper Mapper { get; }

    public BaseController(IMediator mediator, IMapper mapper)
    {
        Mediator = mediator;
        Mapper = mapper;
    }


    protected IActionResult FluentResult<T>(FluentResults.Result<T> result)
    {
        if (result.IsSuccess)
        {
            var customResult = Mapper.Map<CustomResult<T>>(result);

            return Ok(value: customResult);
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