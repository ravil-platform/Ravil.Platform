namespace Application.Api
{
    [ApiController]
    public class GenericBaseController<T>(MediatR.IMediator mediator, Logging.Base.ILogger<T> logger, IMapper mapper)
        : BaseController(mediator, mapper) where T : class
    {
        protected Logging.Base.ILogger<T> Logger { get; } = logger;
    }
}
