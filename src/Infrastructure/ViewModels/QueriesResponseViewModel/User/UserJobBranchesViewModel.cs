namespace ViewModels.QueriesResponseViewModel.User
{
    public class UserJobBranchesViewModel
    {
        public string Id { get; set; }
        public string PictureName { get; set; }

        public string Title { get; set; }
        public string Route { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public int ViewCount { get; set; }
        public int CommentCount { get; set; }
        public int BookMarkCount { get; set; }
        public double Score { get; set; }
    }
}