namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobCategoryRepository : Repository<JobCategory>, IJobCategoryRepository
{
    internal JobCategoryRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}