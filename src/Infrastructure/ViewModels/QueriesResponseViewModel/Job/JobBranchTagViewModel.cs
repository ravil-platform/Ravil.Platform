namespace ViewModels.QueriesResponseViewModel.Job
{
    public class JobBranchTagViewModel
    {
        public int Id { get; set; }

        public string JobBranchId { get; set; }


        public int TagId { get; set; }
        public TagViewModel Tag { get; set; }
    }
}
