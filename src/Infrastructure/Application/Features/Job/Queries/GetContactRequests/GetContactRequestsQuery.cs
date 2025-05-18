using ViewModels.QueriesResponseViewModel.Analytics;

namespace Application.Features.Job.Queries.GetContactRequests;

public class GetContactRequestsQuery : IRequest<ContactRequestViewModel>
{
    public int JobId { get; set; }
}