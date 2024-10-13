namespace Domain.Entities.DayOfWeek
{
    public class DayOfWeek : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }

        public string? AlternateName { get; set; }

        public string PersianName { get; set; } = null!;

        public byte Sort { get; set; }

        public bool IsSelectedPersianName { get; set; } = false;
        #endregion

        #region (Relations)
        public virtual ICollection<JobTimeWork> JobTimeWorks { get; set; }
        #endregion
    }
}
