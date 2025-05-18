namespace Application.Features.Job.Queries.GetJobStatisticsByFilter;

public class GetJobStatisticsByFilterQuery :  IRequest<List<JobStatisticsViewModel>>
{
    public int JobId { get; set; }
    public long? FromDate { get; set; }
    public long? ToDate { get; set; }
}