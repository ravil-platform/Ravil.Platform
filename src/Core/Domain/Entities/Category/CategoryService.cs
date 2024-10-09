namespace Domain.Entities.Category
{
    public class CategoryService : BaseEntity
    {
        #region (Relations)
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int ServiceId { get; set; }
        public virtual Service.Service Service { get; set; }
        #endregion
    }
}
