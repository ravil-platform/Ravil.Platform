using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Constants;
using Domain.Entities.User.Enums;

namespace ViewModels.User
{
    public class CreateUserViewModel
    {
        [Display(Name = "نام")]
        public string? Firstname { get; set; }


        [Display(Name = "نام خانوادگی")]
        public string? Lastname { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public string PasswordHash { get; set; }


        [Display(Name = "کد ملی")]
        [MaxLength(MaxLength.NationalCode, ErrorMessage = "{0} باید {1} رقم باشد.")]
        public string? NationalCode { get; set; }


        [Display(Name = "تلفن همراه")]
        [MaxLength(MaxLength.Phone, ErrorMessage = "{0} باید {1} رقم باشد.")]
        public string? Phone { get; set; }


        [Display(Name = "ایمیل")]
        public string? Email { get; set; }


        [Display(Name = "جنسیت")]
        public GenderPerson GenderType { get; set; }
    }
}
