namespace RNX.Mediator
{
    public class Query<TValue> : object, MediatR.IRequest<Result<TValue>>
    {
        public Query() : base()
        {
        }
    }
}
