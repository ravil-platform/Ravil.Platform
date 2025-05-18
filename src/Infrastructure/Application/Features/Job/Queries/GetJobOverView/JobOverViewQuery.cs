using ViewModels.QueriesResponseViewModel.Analytics;

namespace Application.Features.Job.Queries.GetJobOverView
{
    public class JobOverViewQuery : IRequest<JobOverViewViewModel>
    {
        public int JobId { get; set; }
    }
}
