namespace Domain.Entities.Config.Enums;

public enum ExternalLoginState
{
    [Display(Name = "از طریق کاربر")]
    WithViewPage,
    [Display(Name = "ازطریق اطلاعات گوگل")]
    WithOutViewPage
}