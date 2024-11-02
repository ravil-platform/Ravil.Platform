namespace Application.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        protected RequestDelegate Next { get; }
        protected IWebHostEnvironment Env { get; }
        protected Logging.Base.ILogger<ExceptionHandlerMiddleware> Logger { get; }

        public ExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env, Logging.Base.ILogger<ExceptionHandlerMiddleware> logger)
        {
            Next = next;
            Env = env;
            Logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (AppException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            FluentResults.Result result = new FluentResults.Result();

            FluentValidation.ValidationException? validationException =
                exception as FluentValidation.ValidationException;

            if (validationException != null)
            {
                var code = System.Net.HttpStatusCode.BadRequest;

                context.Response.StatusCode = (int)code;
                context.Response.ContentType = "application/json";

                foreach (var error in validationException.Errors)
                {
                    result.WithError(error.ErrorMessage);
                }
            }
            else
            {
                string message = "";

                if (Env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace!,
                    };
                    if (exception.InnerException != null)
                    {
                        dic.Add("InnerException.Exception", exception.InnerException.Message);
                        dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace!);
                    }

                    message = JsonConvert.SerializeObject(dic);
                }
                else
                {
                    message = exception.Message;
                }

                var code = System.Net.HttpStatusCode.InternalServerError;

                context.Response.StatusCode = (int)code;
                context.Response.ContentType = "application/json";

                result.WithError(message);
            }

            var options = new System.Text.Json.JsonSerializerOptions
            {
                IncludeFields = true,
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
            };

            string resultString = System.Text.Json.JsonSerializer.Serialize(value: result, options: options);

            return context.Response.WriteAsync(resultString);
        }
    }
}
