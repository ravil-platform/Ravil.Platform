namespace Application.Features.Job.Commands.AddJobRanking;

public class AddJobRankingCommandData
{
    #region ( Fields )
    public int JobId { get; set; }

    /// <summary>
    /// آدرس صفحه
    /// </summary>
    public string PageUrl { get; set; } = null!;

    /// <summary>
    /// جایگاه
    /// </summary>
    public int Position { get; set; }

    #endregion
}