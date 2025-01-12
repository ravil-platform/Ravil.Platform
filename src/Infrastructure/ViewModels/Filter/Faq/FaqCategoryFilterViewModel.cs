using Domain.Entities.Faq;

namespace ViewModels.Filter.Faq
{
    public class FaqCategoryFilterViewModel : Paging<FaqCategory>
    {
        public int? ParentId { get; set; }
        public string? Title { get; set; }
        public bool FindAll { get; set; }
    }
}
