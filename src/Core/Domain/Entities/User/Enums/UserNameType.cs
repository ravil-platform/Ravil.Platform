namespace Domain.Entities.User.Enums;

public enum UserNameType
{
    [Display(Name = "تلفن همراه")]
    PhoneNumber,
    [Display(Name = "ایمیل")]
    Email,
    [Display(Name = "سایر")]
    Other
}