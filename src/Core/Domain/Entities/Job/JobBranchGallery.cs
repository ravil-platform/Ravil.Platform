namespace Domain.Entities.Job;

public class JobBranchGallery : BaseEntity
{
    #region (Fields)
    public int Id { get; set; }

    public string ImageName { get; set; }

    public byte Sort { get; set; }
    #endregion

    #region (Relatons)
    public string JobBranchId { get; set; }
    public virtual JobBranch JobBranch { get; set; }
    #endregion
}

