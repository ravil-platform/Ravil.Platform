namespace Application.Features.MainSlider.Queries.GetAllByFilter
{
    public class GetAllMainSlidersByFilterQuery : IRequest<List<MainSliderViewModel>>
    {
        public string? BranchId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }

        public int Take { get; set; } = 1;
    }
}
