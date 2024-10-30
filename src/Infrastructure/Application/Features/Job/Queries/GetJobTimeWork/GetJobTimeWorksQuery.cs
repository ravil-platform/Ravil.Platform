namespace Application.Features.Job.Queries.GetJobTimeWork
{
    public class GetJobTimeWorksQuery : IRequest<List<JobTimeWorkViewModel>>
    {
        public string JobBranchId { get; set; } = null!;
    }
}
