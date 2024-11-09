namespace Application.Api
{
    [ApiController]
    public class GenericBaseController<T> : BaseController where T : class
    {
        protected Logging.Base.ILogger<T> Logger { get; }
     
        public GenericBaseController(MediatR.IMediator mediator, Logging.Base.ILogger<T> logger, IMapper mapper) : base(mediator, mapper)
        {
            Logger = logger;
      }
    }
}
