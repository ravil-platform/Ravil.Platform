
namespace Application.Features.Category.Queries.GetAllByFilter
{
    public class GetAllCategoriesByFilterQuery : IRequest<CategoryFilterViewModel>
    {
        #region ( Paging Fields )
        public int? CurrentPage { get; set; } = 1;

        public int? PagesCount { get; set; }

        public int? EntitiesCount { get; set; }

        public int? StartPage { get; set; }

        public int? EndPage { get; set; }

        public int? PageSize { get; set; } = 9;

        public int? StartPosition { get; set; }

        public int? Step { get; set; } = 5;
        #endregion


        public int? ParentId { get; set; }
        public CategoryBusinessType? Type { get; set; }
        public string? Name { get; set; }
        public short? NodeLevel { get; set; }
        public string? HeadingTitle { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsLastNode { get; set; }


        //public CategoryFilterViewModel CategoryFilterViewModel { get; set; }
    }
}
