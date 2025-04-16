using Domain.Entities.Faq;

namespace Domain.Entities.Category
{
    public class Category : BaseMetaDataEntity
    {
        #region (Fields)
        public CategoryBusinessType Type { get; set; }

        public string Name { get; set; } = null!;

        public string Route { get; set; } = null!;

        public int ParentId { get; set; }

        public short NodeLevel { get; set; }

        public string HeadingTitle { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public bool IsLastNode { get; set; }

        public bool HasAttribute { get; set; } = false;

        public string Picture { get; set; } = null!;

        public string IconPicture { get; set; } = null!;

        public bool IsResizePicture { get; set; } = true;

        public int Sort { get; set; }

        public string PageContent { get; set; } = null!;

        public int ViewCount { get; set; } = 0;
        #endregion

        #region (Relation)
        public virtual ICollection<JobCategory> JobCategories { get; set; }
        public virtual ICollection<CityCategory> CityCategories { get; set; }
        public virtual ICollection<CategoryService> CategoryServices { get; set; }
        public virtual ICollection<FaqJobCategory> FaqJobCategories { get; set; }
        public virtual ICollection<CategoryTag> CategoryTags { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
        #endregion
    }
}
