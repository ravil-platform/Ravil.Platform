namespace Application.Features.Faq.Queries.GetAllByCategoryId
{
    public class GetAllFaqsByCategoryIdQuery : IRequest<List<FaqViewModel>>
    {
        public int CategoryId { get; set; }
    }
}
