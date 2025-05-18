namespace Domain.Entities.Job;

public class JobRankingHistory : BaseEntity
{
    #region (Fields)
    public Guid Id { get; set; }

    /// <summary>
    /// آدرس صفحه
    /// </summary>
    public string PageUrl { get; set; } = null!;
        
    /// <summary>
    /// جایگاه
    /// </summary>
    public int Position { get; set; }

    public DateTime CreateAt { get; set; }
    #endregion

    #region (Relations)
    public int JobId { get; set; }
    public virtual Job Job { get; set; }
    #endregion
}