namespace Domain.Entities.Faq;
public class Faq : BaseEntity
{
    #region (Fields)
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public int Sort { get; set; }

    public string IconPicture { get; set; } = null!;
    #endregion

    #region (Relations)
    public int CategoryId { get; set; }
    public virtual FaqCategory FaqCategory { get; set; }

    public virtual ICollection<FaqJobCategory> FaqJobCategories { get; set; }
    #endregion
}