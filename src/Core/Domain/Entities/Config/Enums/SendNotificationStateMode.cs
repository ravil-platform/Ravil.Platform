namespace Domain.Entities.Config.Enums;

public enum SendNotificationStateMode
{
    [Display(Name = "ارسال ایمیل")]
    SendEmail,
    [Display(Name = "ارسال پیامک")]
    SendSms
}