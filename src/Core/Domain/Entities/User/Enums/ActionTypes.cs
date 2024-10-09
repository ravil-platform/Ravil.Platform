namespace Domain.Entities.User.Enums;

public enum ActionTypes
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
    [Display(Name = "کامنت", GroupName = "نوع عملیات کاربر")]
    CommentAction = 50,
    [Display(Name = "خرید اکانت", GroupName = "نوع عملیات کاربر")]
    OrderAction = 100
}