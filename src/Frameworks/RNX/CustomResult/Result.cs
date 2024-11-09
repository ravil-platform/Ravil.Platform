namespace RNX.CustomResult
{
    public class CustomResult<TValue>
    {

        public bool IsFailed => Reasons.OfType<IError>().Any();

        public bool IsSuccess => !IsFailed;

        public List<IReason> Reasons { get; }

        public List<IError> Errors => Reasons.OfType<IError>().ToList();

        public List<ISuccess> Successes => Reasons.OfType<ISuccess>().ToList();

        public TValue Value { get; set; }
    }
}
