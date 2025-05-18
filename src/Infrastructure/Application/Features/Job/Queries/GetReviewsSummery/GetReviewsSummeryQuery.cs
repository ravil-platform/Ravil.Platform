using ViewModels.QueriesResponseViewModel.Analytics;

namespace Application.Features.Job.Queries.GetReviewsSummery;

public class GetReviewsSummeryQuery : IRequest<ReviewsSummeryViewModel>
{
    public string JobBranchId { get; set; } = null!;
}