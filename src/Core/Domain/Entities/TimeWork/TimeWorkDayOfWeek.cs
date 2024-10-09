namespace Domain.Entities.TimeWork
{
    [NotMapped]
    public class TimeWorkDayOfWeek
    {
        #region (Relations)
        public int DayOfWeekId { get; set; }
        public virtual DayOfWeek.DayOfWeek DayOfWeek { get; set; }
        

        public int TimeWorkId { get; set; }
        public virtual TimeWork TimeWork { get; set; }
        #endregion
    }
}