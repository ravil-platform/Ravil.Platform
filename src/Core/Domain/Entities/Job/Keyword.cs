namespace Domain.Entities.Job;

public class Keyword : BaseMetaDataEntity
{
    public new Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsCategory { get; set; } = false;

    public int CategoryId { get; set; }
    public virtual Category.Category Category { get; set; }

    public virtual ICollection<JobKeyword> JobKeywords { get; set; }
}

