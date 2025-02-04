namespace Application.Features.User.Queries.GetJobBookMarks
{
    public class GetJobBookMarksQuery : IRequest<List<JobBranchViewModel>>
    {
        public string UserId { get; set; } = null!;
    }
}
