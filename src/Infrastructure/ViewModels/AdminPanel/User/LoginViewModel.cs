namespace ViewModels.AdminPanel.User;

public class LoginViewModel
{
    [Display(Name = nameof(DisplayNames.Password), ResourceType = typeof(DisplayNames))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string Password { get; set; } = null!;

    [Display(Name = nameof(DisplayNames.CellPhoneNumber), ResourceType = typeof(DisplayNames))]
    [MaxLength(MaxLength.PhoneNumber, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
    public string? PhoneNumber { get; set; }

    public bool RememberMe { get; set; }
}