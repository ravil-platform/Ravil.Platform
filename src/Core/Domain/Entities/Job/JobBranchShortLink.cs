namespace Domain.Entities.Job;

public class JobBranchShortLink : BaseEntity
{
    #region (Fields)
    public int Id { get; set; }

    public string ShortKey { get; set; } = null!;

    public ShortLinkType Type { get; set; } = ShortLinkType.JobBranch;
    #endregion

    #region (Relaions)
    public string JobBranchId { get; set; }
    public virtual JobBranch JobBranch { get; set; }
    #endregion
}