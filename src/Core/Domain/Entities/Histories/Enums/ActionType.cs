namespace Domain.Entities.Histories.Enums;

public enum ActionType
{
    [Display(Name = "خواندن پست", GroupName = "نوع عملیات کاربر")]
    ReadingAction = 0,
    [Display(Name = "لایک کردن کسب‌وکار", GroupName = "نوع عملیات کاربر")]
    LikeAction = 1,
    [Display(Name = "بازدید صفحه لیستینگ", GroupName = "نوع عملیات کاربر")]
    ViewListingPageAction = 2,
    [Display(Name = "اشتراک گزاری کسب‌وکار", GroupName = "نوع عملیات کاربر")]
    ShareAction = 3,
    [Display(Name = "امتیازدهی به کسب‌وکار", GroupName = "نوع عملیات کاربر")]
    RateAction = 4,
    [Display(Name = "نشان کردن کسب‌وکار", GroupName = "نوع عملیات کاربر")]
    MarkAction = 5,
    [Display(Name = "کامنت", GroupName = "نوع عملیات کاربر")]
    CommentAction = 6,
    [Display(Name = "خرید اشتراک", GroupName = "نوع عملیات کاربر")]
    OrderAction = 7,
    [Display(Name = "ثبت اگهی کسب‌وکار", GroupName = "نوع عملیات کاربر")]
    CreateJobAction = 8,
    [Display(Name = "کلیک روی چت", GroupName = "نوع عملیات کاربر")]
    ClickOnChat = 9,
    [Display(Name = "کلیک روی تصاویر", GroupName = "نوع عملیات کاربر")]
    ClickOnImages = 10,
    [Display(Name = "کلیک روی وب‌سایت", GroupName = "نوع عملیات کاربر")]
    ClickOnWebSite = 11,
    [Display(Name = "کلیک روی مسیریابی", GroupName = "نوع عملیات کاربر")]
    ClickOnMap = 12,
    [Display(Name = "کلیک روی تماس", GroupName = "نوع عملیات کاربر")]
    ClickOnCall = 13,
    [Display(Name = "کلیک روی کارت کسب‌وکار", GroupName = "نوع عملیات کاربر")]
    ClickOnCard = 14,
    [Display(Name = "بازدید کسب‌وکار", GroupName = "نوع عملیات کاربر")]
    JobPageView = 15,
}