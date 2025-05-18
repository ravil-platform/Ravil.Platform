namespace Application.Services.SMS
{
    public interface ISmsSender
    {
        #region ( FarazSms )
        string SendSms(string receiver, string message);
        Task<string> SendPattern(string receiver, string message, string type);
        Task<string> SendPattern(string receiver, string patternCode, string input_data, string smsCenter, string smsPass, string smsUser);
        #endregion


        #region ( KaveNegar Sms )
        Task SendVerificationSms(string mobile, string activationCode);
        Task SendUserPasswordSms(string mobile, string password);
        #endregion
    }
}
