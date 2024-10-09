namespace Domain.Entities.User.Enums;

public enum JobActionType
{
    [Display(Name = "خواندن پست", GroupName = "نوع عملیات کاربر")]
    ReadingAction = 5,
    [Display(Name = "لایک کردن", GroupName = "نوع عملیات کاربر")]
    LikeAction = 15,
    [Display(Name = "بازدید", GroupName = "نوع عملیات کاربر")]
    ViewAction = 10,
    [Display(Name = "اشتراک گزاری", GroupName = "نوع عملیات کاربر")]
    ShareAction = 25,
    [Display(Name = "امتیازدهی", GroupName = "نوع عملیات کاربر")]
    RateAction = 30,
    [Display(Name = "نشان کردن", GroupName = "نوع عملیات کاربر")]
    MarkAction = 35,
    [Display(Name = "کامنت", GroupName = "نوع عملیات کاربر")]
    CommentAction = 50,
    [Display(Name = "خرید اکانت", GroupName = "نوع عملیات کاربر")]
    OrderAction = 100,
    [Display(Name = "ثبت کسب و کار", GroupName = "نوع عملیات کاربر")]
    CreateJobAction = 1000
}