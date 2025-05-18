namespace ViewModels.QueriesResponseViewModel.Job;

public class JobRankingViewModel
{
    #region (Fields)

    /// <summary>
    /// آدرس صفحه
    /// </summary>
    public string PageUrl { get; set; } = null!;

    /// <summary>
    /// میانگین جایگاه
    /// </summary>
    public double AveragePosition { get; set; }

    /// <summary>
    /// تعداد کلیک
    /// </summary>
    public int ClickCount { get; set; } = 0;

    #endregion
}