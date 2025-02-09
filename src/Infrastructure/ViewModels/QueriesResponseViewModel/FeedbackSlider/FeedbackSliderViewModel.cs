namespace ViewModels.QueriesResponseViewModel.FeedbackSlider
{
    public class FeedbackSliderViewModel
    {
        public string UserName { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;


        public byte Sort { get; set; }
    }
}
