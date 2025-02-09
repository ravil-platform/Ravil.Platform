namespace Application.Features.FeedbackSlider.Queries.GetAllByFilter
{
    public class GetAllFeedbackSliderByFilterQuery : IRequest<List<FeedbackSliderViewModel>>
    {
        public int? CategoryId { get; set; }
        public int Take { get; set; } = 8;
    }
}
