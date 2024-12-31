namespace Domain.Entities.Faq;

public class FaqJobCategory : BaseEntity
{
    public int Id { get; set; }


    public int FaqId { get; set; }
    public virtual Faq Faq { get; set; }


    public int JobCategoryId { get; set; }
    public virtual Category.Category Category { get; set; }
}