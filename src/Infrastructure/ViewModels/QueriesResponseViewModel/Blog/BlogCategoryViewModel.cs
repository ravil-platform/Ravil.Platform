namespace ViewModels.QueriesResponseViewModel.Blog
{
    public class BlogCategoryViewModel
    {
        public string Title { get; set; } = null!;

        public byte Sort { get; set; }

        public int ParentId { get; set; }
    }
}
