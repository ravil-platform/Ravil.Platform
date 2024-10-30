namespace ViewModels.QueriesResponseViewModel.Job
{
    public class JobBranchShortLinkViewModel
    {
        public int Id { get; set; }

        public string ShortKey { get; set; } 

        public ShortLinkType Type { get; set; } 

        public string JobBranchId { get; set; }
    }
}
