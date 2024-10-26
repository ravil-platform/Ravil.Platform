namespace Domain.Entities.Histories
{
    public class JobCategoriesView : IEntity
    {
        public int CategoryId { get; set; }
        public int JobId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string BranchTitle { get; set; }
        public string City { get; set; }
    }
}
