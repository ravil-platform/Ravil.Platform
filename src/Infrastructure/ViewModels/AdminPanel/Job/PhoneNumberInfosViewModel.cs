namespace ViewModels.AdminPanel.Job;

public class PhoneNumberInfosViewModel
{
    [Display(Name = "شماره تلفن")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "نوع شماره تماس")]
    public PhoneNumberTypes? PhoneNumberType { get; set; }
}