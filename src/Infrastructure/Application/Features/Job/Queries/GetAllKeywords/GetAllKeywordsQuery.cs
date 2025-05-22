namespace Application.Features.Job.Queries.GetAllKeywords;

public class GetAllKeywordsQuery : IRequest<List<KeywordViewModel>>
{
    public int? CategoryId { get; set; }
}