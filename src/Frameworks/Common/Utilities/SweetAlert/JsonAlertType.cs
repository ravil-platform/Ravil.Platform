namespace Common.Utilities.SweetAlert
{
    public class JsonAlertType
    {
        #region (Fields)
        public string? Message { get; set; }
        public AlertType Type { get; set; }
        #endregion

        #region (Errors)
        public static JsonAlertType Error()
        {
            return new JsonAlertType()
            {
                Type = AlertType.Error,
                Message = "عملیات با خطا مواجه شد!",
            };
        }
        public static JsonAlertType Error(string message)
        {
            return new JsonAlertType()
            {
                Type = AlertType.Error,
                Message = message,
            };
        }
        #endregion

        #region (Succsess)
        public static JsonAlertType Success()
        {
            return new JsonAlertType()
            {
                Type = AlertType.Success,
                Message = "عملیات با موفقیت انجام شد.",
            };
        }
        public static JsonAlertType Success(string message)
        {
            return new JsonAlertType()
            {
                Type = AlertType.Success,
                Message = message,
            };
        }
        #endregion

        #region (Success And Show Basket)
        public static JsonAlertType SuccessAndShowBasket()
        {
            return new JsonAlertType()
            {
                Type = AlertType.SuccessAndShowBasket,
                Message = "عملیات با موفقیت انجام شد.",
            };
        }
        public static JsonAlertType SuccessAndShowBasket(string message)
        {
            return new JsonAlertType()
            {
                Type = AlertType.SuccessAndShowBasket,
                Message = message,
            };
        }
        #endregion

        #region (Info)
        public static JsonAlertType Info()
        {
            return new JsonAlertType()
            {
                Type = AlertType.Info,
                Message = "توجه!",
            };
        }
        public static JsonAlertType Info(string message)
        {
            return new JsonAlertType()
            {
                Type = AlertType.Info,
                Message = message,
            };
        }
        #endregion
    }

    #region (Enum)
    public enum AlertType
    {
        Error = 10,
        Success = 200,
        SuccessAndShowBasket = 201,
        Info = 300
    }
    #endregion
}
