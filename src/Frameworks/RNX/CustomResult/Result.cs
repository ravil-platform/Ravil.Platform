namespace RNX.CustomResult
{
    public class CustomResult<TValue>
    {

        public bool IsFailed => Reasons.OfType<IError>().Any();

        public bool IsSuccess => !IsFailed;

        public List<IReason> Reasons { get; set; }

        public List<IError> Errors => Reasons.OfType<IError>().ToList();

        public List<ISuccess> Successes
        {
            get => Reasons.OfType<ISuccess>().ToList();
            set {  }
        }

        public TValue Value { get; set; }


        public static CustomResult<TValue> ToCustomResult(Result<TValue> result)
        {
            return new CustomResult<TValue>
            {
                Value = result.Value,
                Reasons = result.Reasons,
                Successes = result.Successes,
            };
        }
    }
}
