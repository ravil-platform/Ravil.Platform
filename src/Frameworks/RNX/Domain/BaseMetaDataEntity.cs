using System.ComponentModel.DataAnnotations;

namespace RNX.Domain
{
    public class BaseMetaDataEntity : Entity
    {
        [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
        public string? MetaTitle { get; set; }

        [StringLength(256, MinimumLength = 50, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
        public string? MetaDesc { get; set; }
        public bool IndexMeta { get; set; }
        public bool CanonicalMeta { get; set; }
        public string? MetaCanonicalUrl { get; set; }
    }

    public class BaseMetaDataEntity<TKey> : Entity<TKey>
    {
        [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
        public string? MetaTitle { get; set; }

        [StringLength(256, MinimumLength = 50, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
        public string? MetaDesc { get; set; }
        public bool IndexMeta { get; set; }
        public bool CanonicalMeta { get; set; }
        public string? MetaCanonicalUrl { get; set; }
    }
}