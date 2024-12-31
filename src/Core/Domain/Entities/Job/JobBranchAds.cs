namespace Domain.Entities.Job;

public class JobBranchAds : BaseEntity
{
    #region ( Properties )
    public int Id { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    public string JobBranchId { get; set; }
    public string JobBranchName { get; set; }


    public int Sort { get; set; }

    /// <summary>
    /// if pinned equals true then this JobBranch Shown in all categories at the top
    /// </summary>
    public bool Pinned { get; set; }
    #endregion
}