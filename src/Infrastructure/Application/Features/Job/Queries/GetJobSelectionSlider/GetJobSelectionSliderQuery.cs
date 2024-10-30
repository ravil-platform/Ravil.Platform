namespace Application.Features.Job.Queries.GetJobSelectionSlider
{
    public class GetJobSelectionSliderQuery : IRequest<List<JobSelectionSliderViewModel>>
    {
        public JobSliderType? JobSliderType { get; set; }

        public int? JobId { get; set; }

        public string? JobBranchId { get; set; }
        public int? Take { get; set; }
    }
}
