namespace Domain.Entities.Job
{
    public class JobCategory : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }
        #endregion

        #region (Relations)
        public int CategoryId { get; set; }
        public virtual Category.Category Category { get; set; }

        public int JobId { get; set; }
        public virtual Job Job { get; set; }
        #endregion
    }
}