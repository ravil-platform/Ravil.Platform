namespace ViewModels.QueriesResponseViewModel.Faq
{
    public class FaqCategoryViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } 

        public byte Sort { get; set; }

        public int ParentId { get; set; }
    }
}
