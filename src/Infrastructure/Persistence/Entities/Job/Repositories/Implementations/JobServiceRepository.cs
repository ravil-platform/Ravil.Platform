namespace Persistence.Entities.Job.Repositories;

public class JobServiceRepository : Repository<JobService>, IJobServiceRepository
{
    internal JobServiceRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}