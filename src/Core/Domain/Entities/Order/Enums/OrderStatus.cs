namespace Domain.Entities.Order.Enums;
public enum OrderStatus
{
    [Display(Name = "ایجاد شده")]
    Initial,
    [Display(Name = "پرداخت")]
    PaymentDone,
    [Display(Name = "تایید و اتمام")]
    Completed,
    [Display(Name = "نامعتبر")]
    Unverified
}