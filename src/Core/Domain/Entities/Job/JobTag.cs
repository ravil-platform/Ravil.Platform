namespace Domain.Entities.Job
{
    public class JobTag : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }
        #endregion

        #region (Relations)
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        public int TagId { get; set; }
        public virtual Tag.Tag Tag { get; set; }
        #endregion
    }
}
