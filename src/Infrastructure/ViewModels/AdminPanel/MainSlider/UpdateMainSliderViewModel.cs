namespace ViewModels.AdminPanel.MainSlider;

public class UpdateMainSliderViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Title { get; set; } = null!;

    [Display(Name = "این اسلاید به صورت دائم نمایش داده می شود. شما می توانید یک عدد در فرم زیر وارد کنید تا از امروز به مدت عدد وارد شده منقضی گردد.")]
    public int? ExpireDay { get; set; }

    [Display(Name = "تصویر دسکتاپ")]
    public IFormFile? LargePictureFile { get; set; }
    public string? CurrentLargePicture { get; set; }

    [Display(Name = "تصویر موبایل")]
    public IFormFile? SmallPictureFile { get; set; }
    public string? CurrentSmallPicture { get; set; }


    [Display(Name = "لینک صفحه")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public string LinkPage { get; set; } = null!;

    [Display(Name = "ترتیب")]
    public byte Sort { get; set; }
}