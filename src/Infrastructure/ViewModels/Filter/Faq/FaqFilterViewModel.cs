namespace ViewModels.Filter.Faq;

public class FaqFilterViewModel : Paging<Domain.Entities.Faq.Faq>
{
    public string? Answer { get; set; }
    public string? Question { get; set; }
    public int? CategoryId { get; set; }

    public bool FindAll { get; set; }
}