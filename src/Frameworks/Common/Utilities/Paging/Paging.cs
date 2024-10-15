namespace Common.Utilities.Paging
{
    public class Paging<T>
    {
        #region ( Constructor )
        public Paging()
        {
            PageSize = 9;
            CurrentPage = 1;
            Step = 5;
        }
        #endregion

        #region ( Fields )
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public int EntitiesCount { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public int PageSize { get; set; }

        public int StartPosition { get; set; }

        public int Step { get; set; }

        public List<T> Entities { get; set; }
        #endregion

        #region ( Build )
        public Paging<T> Build(int entitiesCount)
        {
            PagesCount = (int)Math.Ceiling(entitiesCount / (double)PageSize);

            this.EntitiesCount = entitiesCount;
            StartPosition = (CurrentPage - 1) * PageSize;

            StartPage = CurrentPage - Step <= 0 ? 1 : CurrentPage - Step;
            EndPage = CurrentPage + Step > PagesCount ? PagesCount : CurrentPage + Step;

            return this;
        }
        #endregion

        #region (Set Entities)
        public Paging<T> SetEntities(IQueryable<T> queryable)
        {
            Entities = queryable
                .Skip(StartPosition)
                .Take(PageSize)
                .ToList();
            return this;
        }
        #endregion
    }
}