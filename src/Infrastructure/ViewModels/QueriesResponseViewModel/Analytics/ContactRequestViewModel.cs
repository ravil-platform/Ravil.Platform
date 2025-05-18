namespace ViewModels.QueriesResponseViewModel.Analytics;

public class ContactRequestViewModel
{
    public List<ContactRequestDataViewModel>? Data { get; set; }
    public int TotalContactCount { get; set; }
}

public class ContactRequestDataViewModel
{
    public string Date { get; set; }
    public int EventCount { get; set; }
}