
namespace Application.Features.Faq.Queries.GetAll
{
    public class GetAllFaqsQuery : IRequest<List<FaqViewModel>>
    {
        public int? Take { get; set; }
    }
}
