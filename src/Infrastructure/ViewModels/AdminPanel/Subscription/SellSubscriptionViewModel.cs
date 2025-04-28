namespace ViewModels.AdminPanel.Subscription;

public class SellSubscriptionViewModel
{
    [Display(Name = "کاربر سایت")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string UserId { get; set; } = null!;
   
    [Display(Name = "شناسه اشتراک")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public int SubscriptionId { get; set; }
}