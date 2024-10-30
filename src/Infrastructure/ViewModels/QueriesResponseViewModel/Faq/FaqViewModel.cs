namespace ViewModels.QueriesResponseViewModel.Faq
{
    public class FaqViewModel
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; } 

        public int Sort { get; set; }

        public string IconPicture { get; set; } 

        public int CategoryId { get; set; }
    }
}
