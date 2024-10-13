namespace Domain.Entities.Job;

public class JobBranchTag : BaseEntity
{
    #region (Fields)
    public int Id { get; set; }
    #endregion

    #region (Relations)
    public string JobBranchId { get; set; }
    public virtual JobBranch JobBranch { get; set; }


    public int TagId { get; set; }
    public virtual Tag.Tag Tag { get; set; }
    #endregion
}

