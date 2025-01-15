namespace ViewModels.AdminPanel.Job;

public class AddressJobBranchViewModel
{
    public string? JobBranchId { get; set; }
    public string? AddressId { get; set; }
    public string? LocationId { get; set; }

    [Display(Name = "آدرس پستی")]
    public string PostalAddress { get; set; } = null!;

    [Display(Name = "کد پستی")]
    [RegularExpression(@"\d{10}", ErrorMessage = "کد پستی وارد شده صحیح نیست.")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "{0} باید {1} رقم باشد.")]
    public string? PostalCode { get; set; }

    [Display(Name = "استان")]
    public int StateId { get; set; }

    [Display(Name = "شهر")]
    public int CityId { get; set; }

    [Display(Name = "محله، شهرستان")]
    public string Neighbourhood { get; set; } = null!;

    #region ( Location )
    [Display(Name = "طول جغرافیایی")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public double Lat { get; set; }

    [Display(Name = "عرض جغرافیایی")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public double Long { get; set; }
    #endregion

}