namespace Persistence.Entities.Job.Repositories;

public class JobCategoryRepository : Repository<JobCategory>, IJobCategoryRepository
{
    internal JobCategoryRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}