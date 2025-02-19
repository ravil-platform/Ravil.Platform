namespace ViewModels.QueriesResponseViewModel.MainSlider
{
    public class MainSliderViewModel 
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        public string JobBranchId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string LargePicture { get; set; } = null!;
        public string SmallPicture { get; set; } = null!;
        public string LinkPage { get; set; } = null!;

        public int? ExpireDay { get; set; }

        public byte Sort { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        
        public JobBranchViewModel JobBranch { get; set; }
    }
}