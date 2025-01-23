namespace ViewModels.Filter.Category
{
    public class CategoryFilterViewModel : Paging<Domain.Entities.Category.Category, CategoryViewModel>
    {
        public int? Id { get; set; }

        public int? ParentId { get; set; }

        public CategoryBusinessType? Type { get; set; }

        public string? Name { get; set; }

        public short? NodeLevel { get; set; }

        public string? HeadingTitle { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsLastNode { get; set; }
    }
}
