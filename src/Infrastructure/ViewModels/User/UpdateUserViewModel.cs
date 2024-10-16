namespace ViewModels.User
{
    public class UpdateUserViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = nameof(DisplayNames.FirstName), ResourceType = typeof(DisplayNames))]
        public string? Firstname { get; set; }


        [Display(Name = nameof(DisplayNames.LastName), ResourceType = typeof(DisplayNames))]
        public string? Lastname { get; set; }


        [Display(Name = nameof(DisplayNames.Username), ResourceType = typeof(DisplayNames))]
        public string? UserName { get; set; }

        [Display(Name = nameof(DisplayNames.Password), ResourceType = typeof(DisplayNames))]
        public string? PasswordHash { get; set; }


        [Display(Name = nameof(DisplayNames.NationalCode), ResourceType = typeof(DisplayNames))]
        [MaxLength(MaxLength.NationalCode, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public string? NationalCode { get; set; }


        [Display(Name = nameof(DisplayNames.CellPhoneNumber), ResourceType = typeof(DisplayNames))]
        [MaxLength(MaxLength.Phone, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public string? Phone { get; set; }


        [Display(Name = nameof(DisplayNames.EmailAddress), ResourceType = typeof(DisplayNames))]
        public string? Email { get; set; }


        [Display(Name = nameof(DisplayNames.Gender), ResourceType = typeof(DisplayNames))]
        public GenderPerson Gender { get; set; }
    }
}
