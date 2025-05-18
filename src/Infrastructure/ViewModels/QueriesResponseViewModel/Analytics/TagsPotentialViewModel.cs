namespace ViewModels.QueriesResponseViewModel.Analytics;

public class TagsPotentialViewModel
{
    public JobTagsViewModel Tag { get; set; }
    public int ActualView { get; set; }
    public int PotentialView { get; set; }
}
public class JobTagsViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}