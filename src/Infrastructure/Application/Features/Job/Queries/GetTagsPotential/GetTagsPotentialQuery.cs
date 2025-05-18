using ViewModels.QueriesResponseViewModel.Analytics;

namespace Application.Features.Job.Queries.GetTagsPotential;

public class GetTagsPotentialQuery : IRequest<List<TagsPotentialViewModel>>
{
    public int JobId { get; set; }
    public string JobBranchId { get; set; } = null!;
}