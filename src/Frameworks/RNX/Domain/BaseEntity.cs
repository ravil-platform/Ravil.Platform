namespace RNX.Domain
{
    public abstract class BaseEntity : IEntity
    {

    }

    public abstract class Entity<TKey> : BaseEntity
    {
        public TKey Id { get; set; }

        public bool? IsDeleted { get; set; } = false;
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? LastDeleteBicycleDate { get; set; }
        public DateTime? LastDeletePermanentDate { get; set; }
    }

    public abstract class Entity : Entity<int>
    {

    }
}
