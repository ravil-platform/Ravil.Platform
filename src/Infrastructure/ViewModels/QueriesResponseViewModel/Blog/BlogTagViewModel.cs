using ViewModels.QueriesResponseViewModel.Tag;

namespace ViewModels.QueriesResponseViewModel.Blog
{
    public class BlogTagViewModel
    {
        public int BlogId { get; set; }

        public int TagId { get; set; }
        public TagViewModel Tag { get; set; }
    }
}
