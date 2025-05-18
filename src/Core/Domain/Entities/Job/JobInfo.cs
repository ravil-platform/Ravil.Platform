namespace Domain.Entities.Job;

public class JobInfo : BaseEntity
{
    #region ( Fields )
    public int Id { get; set; }

    public int Visit { get; set; }

    public int ClickOnCard { get; set; }
    public int ClickOnCall { get; set; }
    public int ClickOnMap { get; set; }
    public int ClickOnChat { get; set; }
    public int ClickOnImages { get; set; }
    public int ClickOnWebSite { get; set; }
    
    public DateTime CreateAt { get; set; }
    public bool IsActiveAds { get; set; }

    /// <summary>
    /// نسبت تماس به کلیک روی کارت
    /// </summary>
    public double AverageClickOnCall { get; set; }
    #endregion

    #region ( Relations )
    public int JobId { get; set; }
    public virtual Job Job { get; set; }
    #endregion
}