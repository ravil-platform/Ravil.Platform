namespace Domain.Entities.Service;

public class Service : BaseEntity
{
    #region (Fields)
    public string ServiceTitle { get; set; } = null!;

    public string ServiceSummary { get; set; } = null!;

    public string ServicePicture { get; set; } = null!;

    public int ParentId { get; set; }

    public byte Sort { get; set; }
    #endregion

    #region (Relations)
    public virtual ICollection<JobService> JobServices { get; set; }
    public virtual ICollection<CategoryService> CategoryServices { get; set; }
    #endregion
}

