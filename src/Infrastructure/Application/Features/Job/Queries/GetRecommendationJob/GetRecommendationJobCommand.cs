namespace Application.Features.Job.Queries.GetRecommendationJob
{
    public class GetRecommendationJobCommand : IRequest<List<JobBranchViewModel>>
    {
        public string UserId { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
    }
}
