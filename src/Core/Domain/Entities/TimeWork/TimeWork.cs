namespace Domain.Entities.TimeWork;

[NotMapped]
public class TimeWork
{
    #region (Fields)
    public int Id { get; set; }

    public string StartTime { get; set; } = null!;

    public string EndTime { get; set; } = null!;
    #endregion

    #region (Relations)
    public virtual ICollection<TimeWorkDayOfWeek> TimeWorkDayOfWeeks { get; set; }
    #endregion
}