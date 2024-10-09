namespace Logging.Base
{
    public abstract class Logger<T> : object, ILogger<T> where T : class
    {
        #region ( Constructor )
        protected IHttpContextAccessor HttpContextAccessor { get; set; }
        protected Logger(IHttpContextAccessor? httpContextAccessor = null) : base()
        {
            HttpContextAccessor = httpContextAccessor!;
        }
        #endregion

        #region ( Methods )
        #region ( Get Exceptions )
        protected virtual string GetExceptions(Exception exception)
        {
            StringBuilder result = new();

            Exception currentException = exception;

            int index = 0;

            while (currentException != null)
            {
                if (index == 0)
                {
                    result.Append($"<{nameof(Exception)}>");
                }
                else
                {
                    result.Append($"<{nameof(Exception.InnerException)}>");
                }

                result.Append(currentException.Message);

                if (index == 0)
                {
                    result.Append($"</{nameof(Exception)}>");
                }
                else
                {
                    result.Append($"</{nameof(Exception.InnerException)}>");
                }

                index++;

                currentException = currentException.InnerException!;
            }

            return result.ToString();
        }
        #endregion

        #region ( Get Parameters )
        protected virtual string? GetParameters(Hashtable parameters)
        {
            if (parameters == null || parameters.Count == 0)
            {
                return null;
            }

            StringBuilder stringBuilder = new();

            foreach (DictionaryEntry item in parameters)
            {
                if (item.Key != null)
                {
                    stringBuilder.Append("<parameter>");

                    stringBuilder.Append($"<key>{item.Key}</key>");

                    if (item.Value == null)
                    {
                        stringBuilder.Append($"<value>NULL</value>");
                    }
                    else
                    {
                        stringBuilder.Append($"<value>{item.Value}</value>");
                    }

                    stringBuilder.Append("</parameter>");
                }
            }

            string result = stringBuilder.ToString();

            return result;
        }
        #endregion

        #region ( Log )
        protected void Log(LogLevel level, MethodBase methodBase, string message, Exception? exception = null, Hashtable? parameters = null)
        {
            if (exception == null && string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            string currentCultureName = Thread.CurrentThread.CurrentCulture.Name;

            CultureInfo newCultureInfo = new(name: "en-US");

            CultureInfo currentCultureInfo = new(currentCultureName);

            Thread.CurrentThread.CurrentCulture = newCultureInfo;

            Log log = new()
            {
                Level = level,
                ClassName = typeof(T).Name,
                MethodName = methodBase.Name,
                Namespace = typeof(T).Namespace!
            };

            if (HttpContextAccessor != null &&
                HttpContextAccessor.HttpContext != null &&
                HttpContextAccessor.HttpContext.Connection != null &&
                HttpContextAccessor.HttpContext.Connection.RemoteIpAddress != null)
            {
                log.RemoteIP = HttpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            if (HttpContextAccessor != null &&
                HttpContextAccessor.HttpContext != null &&
                HttpContextAccessor.HttpContext.User != null &&
                HttpContextAccessor.HttpContext.User.Identity != null)
            {
                log.Username = HttpContextAccessor.HttpContext.User.Identity.Name!;
            }

            if (HttpContextAccessor != null &&
                HttpContextAccessor.HttpContext != null &&
                HttpContextAccessor.HttpContext.Request != null)
            {
                log.RequestPath = HttpContextAccessor.HttpContext.Request.Path;

                log.HttpReferrer = HttpContextAccessor.HttpContext.Request.Headers[HeaderNames.Referer];
            }

            log.Message = message;

            log.Exceptions = GetExceptions(exception!);

            log.Parameters = GetParameters(parameters);

            LogByFavoriteLibrary(log, exception!);

            Thread.CurrentThread.CurrentCulture = currentCultureInfo;
        }
        #endregion

        #region ( Logs Leveles )
        protected abstract void LogByFavoriteLibrary(Log log, Exception exception);

        public void LogTrace(string message, Hashtable? parameters = null)
        {
            StackTrace stackTrace = new();

            MethodBase methodBase = stackTrace.GetFrame(1)!.GetMethod()!;

            Log(methodBase: methodBase,
                level: LogLevel.Trace,
                message: message,
                exception: null,
                parameters: parameters);
        }

        public void LogDebug(string message, Hashtable? parameters = null)
        {
            StackTrace stackTrace = new();

            MethodBase methodBase = stackTrace.GetFrame(1)!.GetMethod()!;

            Log(methodBase: methodBase,
                level: LogLevel.Debug,
                message: message,
                exception: null,
                parameters: parameters);
        }

        public void LogInformation(string message, Hashtable? parameters = null)
        {
            StackTrace stackTrace = new();

            MethodBase methodBase = stackTrace.GetFrame(1)!.GetMethod()!;

            Log(methodBase: methodBase,
                level: LogLevel.Information,
                message: message,
                exception: null,
                parameters: parameters);
        }

        public void LogWarning(string message, Hashtable? parameters = null)
        {
            StackTrace stackTrace = new();

            MethodBase methodBase = stackTrace.GetFrame(1)!.GetMethod()!;

            Log(methodBase: methodBase,
                level: LogLevel.Warning,
                message: message,
                exception: null,
                parameters: parameters);
        }

        public void LogError(Exception? exception = null, string? message = null, Hashtable? parameters = null)
        {
            StackTrace stackTrace = new();

            MethodBase methodBase = stackTrace.GetFrame(1)!.GetMethod()!;

            Log(methodBase: methodBase,
                level: LogLevel.Error,
                message: message!,
                exception: exception,
                parameters: parameters);
        }

        public void LogCritical(Exception? exception = null, string? message = null, Hashtable? parameters = null)
        {
            StackTrace stackTrace = new();

            MethodBase methodBase = stackTrace.GetFrame(1)!.GetMethod()!;

            Log(methodBase: methodBase,
                level: LogLevel.Critical,
                message: message!,
                exception: exception,
                parameters: parameters);
        }
        #endregion
        #endregion
    }
}
