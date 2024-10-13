namespace Domain.Entities.Job
{
    public class JobTimeWork : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }

        public string StartTime { get; set; } = null!;

        public string EndTime { get; set; } = null!;
        #endregion

        #region (Relations)
        public string JobBranchId { get; set; }
        public virtual JobBranch JobBranch { get; set; }


        public int DayOfWeekId { get; set; }
        public virtual DayOfWeek.DayOfWeek DayOfWeek { get; set; }
        #endregion
    }
}
