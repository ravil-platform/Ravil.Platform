namespace Domain.Entities.RedirectionUrl.Enums;

public enum RedirectionTypes
{
    [Display(Name = "کاملا انتقال یافت 301")]
    MovedPermanently301 = 301,
    [Display(Name = "پیدا شد 302")]
    Found302 = 302,
    [Display(Name = "به طور موقت تغییر مسیر داده شد 307")]
    TemporaryRedirect307 = 307,
    [Display(Name = "به دلایل امنیتی غیرقابل دسترسی است 451")]
    UnavailableForLegalReasons451 = 451,
    [Display(Name = "محتوای حذف شده 410")]
    Gone410 = 410
}