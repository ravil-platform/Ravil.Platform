namespace ViewModels.AdminPanel.MainSlider;

public class CreateMainSliderViewModel
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Title { get; set; } = null!;

    [Display(Name = "این اسلاید به صورت دائم نمایش داده می شود. شما می توانید یک عدد در فرم زیر وارد کنید تا از امروز به مدت عدد وارد شده منقضی گردد.")]
    public int? ExpireDay { get; set; }

    [Display(Name = "تصویر دسکتاپ")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public IFormFile LargePictureFile { get; set; } = null!;

    [Display(Name = "تصویر موبایل")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public IFormFile SmallPictureFile { get; set; } = null!;

    [Display(Name = "لینک صفحه")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string LinkPage { get; set; } = null!;

    [Display(Name = "ترتیب")]
    public byte Sort { get; set; }

    [Display(Name = "شغل")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string JobBranchId { get; set; } = null!;

    [Display(Name = "استان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public int StateId { get; set; }

    [Display(Name = "شهر")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public int CityId { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
}