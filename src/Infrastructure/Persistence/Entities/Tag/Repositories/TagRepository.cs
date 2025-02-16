using ViewModels.AdminPanel.Filter.Blog;

namespace Persistence.Entities.Tag.Repositories;

public class TagRepository : Repository<Domain.Entities.Tag.Tag>, ITagRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal TagRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public TagsFilterViewModel GetByFilter(TagsFilterViewModel filter)
    {
        var query = ApplicationDbContext.Tag.AsQueryable();

        #region ( Filter )
        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(x => x.Name.Contains(filter.Name));
        }

        if (filter.TagType != null)
        {
            query = query.Where(x => x.Type == filter.TagType);
        }

        if (filter.TagType == TagType.Category)
        {
            query = query.Include(t => t.CategoryTags).ThenInclude(t => t.Category);
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}