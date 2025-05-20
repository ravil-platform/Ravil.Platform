namespace ViewModels.AdminPanel.PanelTutorial
{
    public class CreatePanelTutorialViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public string Title { get; set; } = null!;


        [Display(Name = "کاور ویدیو")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public IFormFile CoverNameFile { get; set; } = null!;


        [Display(Name = "ویدیو")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public IFormFile VideoNameFile { get; set; } = null!;


        [Display(Name = "زمان ویدیو")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public TimeSpan Time { get; set; }


        [Display(Name = "ترتیب")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public int Sort { get; set; }
    }
}
