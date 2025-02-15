namespace ViewModels.AdminPanel.Job
{
    public class InsertJobsFromGoogle
    {
        [Display(Name = "شهر یا منطقه")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public int CityId { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public int CategoryId { get; set; }

        [Display(Name = "آپلود فایل به فرمت Json")]
        public IFormFile File { get; set; }
    }
}
