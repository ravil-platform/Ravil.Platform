namespace Domain.Entities.Job;

public class JobKeyword : BaseEntity
{
    public long Id { get; set; }


    public string JobBranchId { get; set; } = null!;
    public required JobBranch JobBranch { get; set; }

    public Guid KeywordId { get; set; }
    public required Keyword Keyword { get; set; } 

    public int CostPerClick { get; set; }
}