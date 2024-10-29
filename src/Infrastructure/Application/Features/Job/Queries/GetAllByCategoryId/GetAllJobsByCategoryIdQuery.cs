using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Job;

namespace Application.Features.Job.Queries.GetAllByCategoryId
{
    public class GetAllJobsByCategoryIdQuery : IRequest<List<JobViewModel>>
    {
        public int CategoryId { get; set; }
        public int Take { get; set; }
    }
}
