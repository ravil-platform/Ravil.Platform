namespace Application.Features.Job.Queries.GetAllJobBranch
{
    public class GetAllJobBranchByFilterQuery : IRequest<JobBranchFilter>
    {
        public int? CategoryId { get; set; }

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
    }
}