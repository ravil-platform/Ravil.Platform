namespace Domain.Entities.Faq;
public class FaqCategory : BaseEntity
{
    #region (Fields)
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public byte Sort { get; set; }

    public int ParentId { get; set; }
    #endregion

    #region (Relations)
    public virtual ICollection<Faq> Faqs { get; set; }
    #endregion
}

