namespace Domain.Entities.Job
{
    public class JobService : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }
        #endregion

        #region (Relations)
        public string JobBranchId { get; set; }
        public virtual JobBranch JobBranch { get; set; }

        public int ServiceId { get; set; }
        public virtual Service.Service Service { get; set; }
        #endregion
    }
}