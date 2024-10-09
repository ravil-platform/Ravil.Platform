namespace Domain.Entities.Common
{
    public abstract class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
        public DateTime LastDeleteBicycleDate { get; set; }
        public DateTime LastDeletePermanentDate { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<int>
    {

    }
}
