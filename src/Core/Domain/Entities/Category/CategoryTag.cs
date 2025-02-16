namespace Domain.Entities.Category
{
    public class CategoryTag : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int TagId { get; set; }
        public Tag.Tag Tag { get; set; }
    }
}
