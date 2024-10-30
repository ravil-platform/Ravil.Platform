namespace Application.Features.Job.Queries.GetByRoute
{
    public class GetJobByRouteQuery : IRequest<JobViewModel>
    {
        public string Route { get; set; }
    }
}
