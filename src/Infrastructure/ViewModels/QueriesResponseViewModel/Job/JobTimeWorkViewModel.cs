namespace ViewModels.QueriesResponseViewModel.Job
{
    public class JobTimeWorkViewModel
    {
        public int TimeWorkId { get; set; }

        [Required]

        public string JobBranchId { get; set; }

        public int DayOfWeekId { get; set; }


        [Display(Name = "از ساعت")]
        [StringLength(256, ErrorMessage = "{0} باید بین {3} تا {2} کاراکتر باشد.")]
        public string StartTime { get; set; }

        [Display(Name = "تا ساعت")]
        [StringLength(256, ErrorMessage = "{0} باید بین {3} تا {2} کاراکتر باشد.")]
        public string EndTime { get; set; }
    }
}
