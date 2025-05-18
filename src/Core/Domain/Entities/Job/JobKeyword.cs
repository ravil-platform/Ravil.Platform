namespace Domain.Entities.Job;

public class JobKeyword : BaseEntity
{
    public long Id { get; set; }

    public string JobBranchId { get; set; } = null!;
    public virtual JobBranch JobBranch { get; set; }

    public Guid KeywordId { get; set; }
    public virtual Keyword Keyword { get; set; }
}