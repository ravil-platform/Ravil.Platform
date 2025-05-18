namespace Application.Features.Job.Queries.GetJobRankingsByFilter;

public class GetJobRankingsByFilterQuery : IRequest<List<JobRankingViewModel>>
{
    public int JobId { get; set; }
    public long? FromDate { get; set; }
    public long? ToDate { get; set; }
}