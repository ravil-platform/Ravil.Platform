namespace ViewModels.QueriesResponseViewModel.Service
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string ServiceTitle { get; set; } = null!;
        public string ServiceSummary { get; set; } = null!;
        public string ServicePicture { get; set; } = null!;

        public int ParentId { get; set; }
        public byte Sort { get; set; }
    }
}
