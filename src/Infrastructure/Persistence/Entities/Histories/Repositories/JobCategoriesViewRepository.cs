namespace Persistence.Entities.Histories.Repositories;

public class JobCategoriesViewRepository : Repository<JobCategoriesView> , IJobCategoriesViewRepository
{
    internal JobCategoriesViewRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}