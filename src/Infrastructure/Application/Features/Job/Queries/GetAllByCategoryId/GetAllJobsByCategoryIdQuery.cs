namespace Application.Features.Job.Queries.GetAllByCategoryId
{
    public class GetAllJobsByCategoryIdQuery : IRequest<List<JobBranchViewModel>>
    {
        public int CategoryId { get; set; }
        public int Take { get; set; }
    }
}
