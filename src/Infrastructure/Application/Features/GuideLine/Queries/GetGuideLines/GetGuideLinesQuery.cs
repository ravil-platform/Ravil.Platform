using ViewModels.QueriesResponseViewModel.Job.GuideLines;

namespace Application.Features.GuideLine.Queries.GetGuideLines
{
    public class GetGuideLinesQuery : IRequest<GuideLineCompletionViewModel>
    {
        public int JobId { get; set; }
        public string UserId { get; set; } = null!;
    }
}
