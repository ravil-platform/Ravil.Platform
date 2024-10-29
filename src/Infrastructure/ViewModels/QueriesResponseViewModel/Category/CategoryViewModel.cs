namespace ViewModels.QueriesResponseViewModel.Category
{
    public class CategoryViewModel
    {
        public CategoryBusinessType Type { get; set; }

        public string Name { get; set; } = null!;

        public string Route { get; set; } = null!;

        public int ParentId { get; set; }

        public short NodeLevel { get; set; }

        public string HeadingTitle { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public bool IsLastNode { get; set; }


        public string Picture { get; set; } = null!;

        public string IconPicture { get; set; } = null!;

        public int Sort { get; set; }

        public string PageContent { get; set; } = null!;
    }
}
