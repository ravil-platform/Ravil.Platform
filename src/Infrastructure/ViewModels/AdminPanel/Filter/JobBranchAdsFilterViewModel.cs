namespace ViewModels.AdminPanel.Filter;

public class JobBranchAdsFilterViewModel : Paging<JobBranchAds>
{
    public string? JobBranchName { get; set; }

    public bool FindAll { get; set; }
}