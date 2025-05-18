namespace ViewModels.QueriesResponseViewModel.Job;

public class JobStatisticsViewModel
{
    #region ( Fields )
    public int Id { get; set; }
    public int JobId { get; set; }
    public DateTime CreateAt { get; set; }
    public int Visit { get; set; }
    public int ClickOnCard { get; set; }
    public int ClickOnCall { get; set; }
    public int ClickOnMap { get; set; }
    public int ClickOnChat { get; set; }
    public int ClickOnImages { get; set; }
    public int ClickOnWebSite { get; set; }
    public double AverageClickOnCall { get; set; }
    public bool IsActiveAds { get; set; }
    #endregion
}