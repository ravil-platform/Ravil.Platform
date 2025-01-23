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
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (ForbiddenAccessException ex)
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

            if (exception is ValidationException validationException)
            {
                var code = System.Net.HttpStatusCode.BadRequest;
                var optionsJson = new JsonSerializerSettings()
                {
                    Formatting = Formatting.None,
                };

                context.Response.StatusCode = (int)code;
                context.Response.ContentType = MimeTypeNames.ApplicationJson;

                foreach (var error in validationException.Errors)
                {
                    if (error != null)
                    {
                        var errorMessage = new ValidationErrorMessage
                        {
                            PropertyName = error.PropertyName,
                            ErrorMessage = error.ErrorMessage
                        };

                        var message = JsonConvert.SerializeObject(errorMessage, optionsJson);
                        result.WithError(message.Replace(@"\", ""));
                    }
                }
            }
            else
            {
                string message = "";

                System.Net.HttpStatusCode code = exception switch
                {
                    NotFoundException => System.Net.HttpStatusCode.NotFound,
                    BadRequestException => System.Net.HttpStatusCode.BadRequest,
                    UnauthorizedAccessException => System.Net.HttpStatusCode.Unauthorized,
                    ForbiddenAccessException => System.Net.HttpStatusCode.Forbidden,
                    _ => System.Net.HttpStatusCode.InternalServerError
                };

                if (Env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace ?? string.Empty,
                    };
                    if (exception.InnerException != null)
                    {
                        dic.Add("InnerException.Exception", exception.InnerException.Message);
                        dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace ?? string.Empty);
                    }

                    message = JsonConvert.SerializeObject(dic);
                    message = message.Replace(@"\", "");

                    if (code is System.Net.HttpStatusCode.BadRequest
                        or System.Net.HttpStatusCode.BadGateway
                        or System.Net.HttpStatusCode.NotExtended
                        or System.Net.HttpStatusCode.GatewayTimeout
                        or System.Net.HttpStatusCode.ServiceUnavailable
                        or System.Net.HttpStatusCode.HttpVersionNotSupported
                        or System.Net.HttpStatusCode.InternalServerError)
                    {
                        Logger.LogError(exception: exception, message: message);
                    }
                }
                else
                {
                    message = exception.Message;
                }

                context.Response.StatusCode = (int)code;
                context.Response.ContentType = MimeTypeNames.ApplicationJson;

                Logger.LogError(exception, message);

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
