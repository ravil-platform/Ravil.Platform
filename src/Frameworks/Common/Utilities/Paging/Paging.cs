using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Common.Utilities.Paging
{
    /// <summary>
    /// Admin Pagination
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
        public virtual Paging<T> SetEntities(IQueryable<T> queryable)
        {
            Entities = queryable
                .Skip(StartPosition)
                .Take(PageSize)
                .ToList();
            return this;
        }
        #endregion
    }

    /// <summary>
    /// Api Pagination
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    public class Paging<T, TDto>
    {
        #region ( Fields )
        public int CurrentPage { get; set; } = 1;

        public int PagesCount { get; set; }

        public int EntitiesCount { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public int PageSize { get; set; } = 9;

        public int StartPosition { get; set; }

        public int Step { get; set; } = 5;

        public List<TDto> DtoEntities { get; set; } = null!;
        #endregion

        #region ( Build )
        public new Paging<T, TDto> Build(int entitiesCount)
        {
            PagesCount = (int)Math.Ceiling(entitiesCount / (double)PageSize);

            this.EntitiesCount = entitiesCount;
            StartPosition = (CurrentPage - 1) * PageSize;

            StartPage = CurrentPage - Step <= 0 ? 1 : CurrentPage - Step;
            EndPage = CurrentPage + Step > PagesCount ? PagesCount : CurrentPage + Step;

            return this;
        }
        #endregion

        #region ( Set Entities )
        public Paging<T, TDto> SetEntities(IQueryable<T> queryable, IMapper mapper, bool? hasNoPagination = null)
        {
            if (!hasNoPagination.HasValue)
            {
                var query = queryable
                    .Skip(StartPosition)
                    .Take(PageSize)
                    .ToList();

                DtoEntities = mapper.Map<List<TDto>>(query);
            }
            else
            {
                var query = queryable.ToList();

                DtoEntities = mapper.Map<List<TDto>>(query);
            }

            return this;
        }
        #endregion
    }
}