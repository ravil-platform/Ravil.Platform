namespace ViewModels.AdminPanel.Subscription;

public class CreateSubscriptionViewModel
{
    [Display(Name = "آیکن")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public IFormFile Icon { get; set; } = null!;

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string Title { get; set; } = null!;


    [Display(Name = "زیر عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string SubTitle { get; set; } = null!;

    [Display(Name = "قیمت")]
    public int Price { get; set; }

    [Display(Name = "تخفیف")]
    public short? Discount { get; set; }

    [Display(Name = "شارژ هدیه")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public int GiftCharge { get; set; }

    [Display(Name = "تعداد روز ")]
    public int DurationTime { get; set; } // Ex:  30 Days

    [Display(Name = "زمان")]
    public SubscriptionDurationType DurationType { get; set; }

    [Display(Name = "نوع")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public SubscriptionType Type { get; set; }

    [Display(Name = "وضعیت")]
    public bool IsActive { get; set; }


    [Display(Name = "ویژگی ها")]
    public int[]? Features { get; set; }
}