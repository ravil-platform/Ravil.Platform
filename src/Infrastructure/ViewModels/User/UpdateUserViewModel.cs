namespace ViewModels.User
{
    public class UpdateUserViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "نام")]
        public string? Firstname { get; set; }


        [Display(Name = "نام خانوادگی")]
        public string? Lastname { get; set; }


        [Display(Name = "نام کاربری")]
        public string? UserName { get; set; } 

        [Display(Name = "کلمه عبور")]
        public string? PasswordHash { get; set; } 


        [Display(Name = "کد ملی")]
        [MaxLength(MaxLength.NationalCode, ErrorMessage = "{0} باید {1} رقم باشد.")]
        public string? NationalCode { get; set; }


        [Display(Name = "تلفن همراه")]
        [MaxLength(MaxLength.Phone, ErrorMessage = "{0} باید {1} رقم باشد.")]
        public string? Phone { get; set; }


        [Display(Name = "ایمیل")]
        public string? Email { get; set; }


        [Display(Name = "جنسیت")]
        public GenderPerson Gender { get; set; }
    }
}
