namespace Application.Features.Job.Queries.GetTags
{
    public class GetJobTagsByIdQuery : IRequest<List<JobTagViewModel>>
    {
        public int JobId { get; set; }
    }
}
