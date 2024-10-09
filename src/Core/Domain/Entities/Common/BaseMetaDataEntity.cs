namespace Domain.Entities.Common
{
    public class BaseMetaDataEntity : BaseEntity
    {
        public string MetaTitle { get; set; } = null!;
        public string MetaDesc { get; set; } = null!;
        public bool IndexMeta { get; set; }
        public bool CanonicalMeta { get; set; }
        public string MetaCanonicalUrl { get; set; } = null!;
    }

    public class BaseMetaDataEntity<TKey> : BaseEntity<TKey>
    {
        public string MetaTitle { get; set; } = null!;
        public string MetaDesc { get; set; } = null!;
        public bool IndexMeta { get; set; }
        public bool CanonicalMeta { get; set; }
        public string MetaCanonicalUrl { get; set; } = null!;
    }
}
