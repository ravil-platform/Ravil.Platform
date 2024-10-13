namespace Persistence.Entities.Tag.Repositories;

public class TagRepository : Repository<Domain.Entities.Tag.Tag>, ITagRepository
{
    internal TagRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}