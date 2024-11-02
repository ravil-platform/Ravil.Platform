
namespace Application.Features.Job.Queries.GetAllJobService
{
    public class GetAllJobServiceQuery : IRequest<List<JobServiceViewModel>>
    {
        public string? JobBranchId { get; set; }

        public int? ServiceId { get; set; }
    }
}
