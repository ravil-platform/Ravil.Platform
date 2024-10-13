namespace Domain.Entities.Histories.Enums;

public enum ActionType
{
    [Display(Name = "خواندن پست", GroupName = "نوع عملیات کاربر")]
    ReadingAction = 0,
    [Display(Name = "لایک کردن", GroupName = "نوع عملیات کاربر")]
    LikeAction = 1,
    [Display(Name = "بازدید", GroupName = "نوع عملیات کاربر")]
    ViewAction = 2,
    [Display(Name = "اشتراک گزاری", GroupName = "نوع عملیات کاربر")]
    ShareAction = 3,
    [Display(Name = "امتیازدهی", GroupName = "نوع عملیات کاربر")]
    RateAction = 4,
    [Display(Name = "نشان کردن", GroupName = "نوع عملیات کاربر")]
    MarkAction = 5,
    [Display(Name = "کامنت", GroupName = "نوع عملیات کاربر")]
    CommentAction = 6,
    [Display(Name = "خرید اکانت", GroupName = "نوع عملیات کاربر")]
    OrderAction = 7,
    [Display(Name = "ثبت کسب و کار", GroupName = "نوع عملیات کاربر")]
    CreateJobAction = 8
}