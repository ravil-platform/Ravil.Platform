namespace Persistence.Entities.Job.Repositories;

public class JobTagRepository : Repository<JobTag>, IJobTagRepository
{
    internal JobTagRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}