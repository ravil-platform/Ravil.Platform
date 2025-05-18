namespace ViewModels.QueriesResponseViewModel.Analytics;

public class JobViewsViewModel
{
    public List<ClickViewJobsViewModel>? Data { get; set; }
    public int TotalClicks { get; set; }
}

public class ClickViewJobsViewModel
{
    public string Date { get; set; }
    public int WithAds { get; set; }
    public int WithoutAds { get; set; }
}