
namespace ViewModels.Filter.Job
{
    public class JobBranchFilter : Paging<JobBranch, JobBranchViewModel>
    {
        public int? CategoryId { get; set; }
    }
}
