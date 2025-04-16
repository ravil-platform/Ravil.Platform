namespace Domain.Entities.Job;

public class Keyword : BaseEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public bool  IsActive { get; set; }

    public int CategoryId { get; set; }
    public Category.Category Category { get; set; }

    public virtual ICollection<JobKeyword> JobKeywords { get; set; }
}

