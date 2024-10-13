namespace Domain.Entities.Job;

public class JobBranchAttr : BaseEntity
{
    #region (Fields)
    public int Id { get; set; }
    #endregion

    #region (Relations)
    public string JobBranchId { get; set; } = null!;
    public virtual JobBranch JobBranch { get; set; }


    [Required]
    public int AttrId { get; set; }
    public virtual Attr.Attr Attr { get; set; }


    [Required]
    [ForeignKey("AttrValue")]
    public int ValueId { get; set; }
    public virtual AttrValue AttrValue { get; set; }
    #endregion
}
