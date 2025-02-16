
namespace ViewModels.Filter.Job
{
    public class JobBranchFilter : Paging<JobBranch, JobBranchViewModel>
    {
        public int? CityId { get; set; }
        public int? CategoryId { get; set; }
    }
}
