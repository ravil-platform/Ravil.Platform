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

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}