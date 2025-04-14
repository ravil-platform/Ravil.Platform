namespace ViewModels.AdminPanel.Filter;

public class JobFilterViewModel : Paging<Domain.Entities.Job.Job>
{
    public string? Route { get; set; }
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? Summary { get; set; }
    public string? Content { get; set; }

    public bool? HasNotAnyJobBranches { get; set; }
    public bool? IsGoogleData { get; set; }
    public bool? IsDuplicate { get; set; }
    public bool? IsEnglishOnly { get; set; }

    public JobBranchStatus? Status { get; set; }
    public JobSortedBy? SortedBy { get; set; }
    public bool? IsDeleted { get; set; }
    public bool FindAll { get; set; }


    public DateTime? CreatedDateFrom { get; set; }
    public DateTime? CreatedDateTo { get; set; }
}

public enum JobSortedBy
{
    Newest, Oldest,
}